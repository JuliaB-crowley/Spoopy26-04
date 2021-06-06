using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using combat;

namespace character
{
    public enum DirectionAngle {North, Est, South, West}
    public enum DirectionObject { North, Est, South, West}
    public class JUB_Maeve : MonoBehaviour
    {
        //collisions
        public JUB_MaeveCollisionDetector left, right, top, bottom;
        public bool collisionLeft, collisionRight, collisionTop, collisionBottom;

        //mouvements
        Rigidbody2D rigidBody;
        Controller controller;
        public float speed, rollSpeed, rollDuration, rollRecover, crouchSpeed, xVelocity, yVelocity, accelerationTime;
        Vector2 rStick, lStick, lStickNormalised, lastDirection, rollDirection, targetSpeed, currentSpeed;
        public float lastAngle, correctionAngle;
        public DirectionAngle dirAngle;
        public DirectionObject dirObject;
        public float knockbackDuration, knockbackForce;


        [SerializeField]
        bool isInRoll,  isInRecoil, isInImmunity, isInRecover, isPushingObject, isInKnockback;
        public bool isFlashing;
        public LayerMask pushableObjects, interactibleObjects;
        public bool isCrouching;
        [SerializeField]
        bool attackMaintained, isInBuildup, isInAttack;

        //combat
        public Transform attackPoint;
        public float attackRange, attackTime;
        public Vector2 quickAtkZone, heavyAtkZone;
        public LayerMask ennemies, breakableObjects, bossJewel;
        public int attackDamage;
        public bool ennemyWasHitOnce;
        List<Collider2D> ennemiesHitLastTime = new List<Collider2D>();
        public float immunityTime, timeRed;
        public Renderer rendererMaeve;

        //ded
        public Transform actualCheckpoint;
        public float deathAnimDuration;

        //pousser des objets
        Collider2D[] allPushableInRange, allInteractibleInRange;
        public float interactAndPushableRange;

        //HUD
        public int maxLife, currentLife, currentBonbons;
        public Text displayLife, displayBonbons;
        public Sprite[] heartSprites;
        public Image heartsDisplay;

        //dialogue
        public bool isInDialogue;

        //anim
        public int animationIndex; //-1 mort, 0 idle, 1 course, 2 attaque, 3 flash, 4 roulade, 5 accroupi, 6 déplacement objet, 7 accroupi iddle, 8 immunité
        public Animator maeveAnimator;
        public GameObject deathCanvas;
        public string jeuSceneName;
        public GameObject mainCam;
        public float ennemyScreenshakeAmount, bossScreenshakeAmount, screenshakeDuration;
        public ParticleSystem deathParticles, dust;
        public GameObject paquetBonbons, shaderFlame;
        Vector3 paquetOriginalScale;

        //attack profile
        public float quickDamage = 1, heavyDamage = 3;
        public JUB_Combat.AttackProfile quickAttack, heavyAttack;

        // Start is called before the first frame update
        void Start()
        {
            deathParticles.Stop();

            rigidBody = GetComponent<Rigidbody2D>();
            mainCam = GameObject.FindGameObjectWithTag("MainCamera");
            controller = new Controller();
            controller.Enable();
            displayBonbons.text = currentBonbons.ToString();

            paquetOriginalScale = paquetBonbons.transform.localScale;

            quickAttack = new JUB_Combat.AttackProfile(quickDamage, new Vector2(1, 1), 0.4f, 0.2f, "quick");
            heavyAttack = new JUB_Combat.AttackProfile(heavyDamage, new Vector2(2, 1), 0.4f, 0.8f, "heavy");

            currentLife = maxLife;
            deathCanvas.SetActive(false);


            controller.MainController.Roll.performed += ctx => Roll();  
            controller.MainController.Crouch.performed += ctx => Crouch();
            controller.MainController.Push.performed += ctx => PushObjects();
            controller.MainController.Interact.performed += ctx => Interact();
            //controller.MainController.Crouch.performed += ctx => isCrouching = !isCrouching;
            controller.MainController.Attack.performed += ctx => Attack(quickAttack);// Attack();
            controller.MainController.HeavyAttack.performed += ctx => Attack(heavyAttack);

            shaderFlame.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            Inputs();
            InteractSphere();
            PushableSphere();
            if (!isInKnockback)
            {
                Move();

            }
            else
            {
                Collisions();
            }

            displayLife.text = currentLife.ToString() + " / " + maxLife.ToString();
            if (currentLife > maxLife)
            {
                currentLife = maxLife;
            }

            if(currentLife <= 0)
            {
                heartsDisplay.sprite = heartSprites[0];
            }
            else 
            { 
                heartsDisplay.sprite = heartSprites[currentLife - 1];
            }
            shaderFlame.SetActive(false); 
            Anim();
        }

        void Inputs()
        {
            lStick = controller.MainController.Move.ReadValue<Vector2>();
            lStickNormalised = lStick.normalized;

            if (lStick != Vector2.zero)
            {
                lastDirection = lStickNormalised;
                lastAngle = Vector2.Angle(Vector2.up, lastDirection);
                correctionAngle = Vector2.Angle(Vector2.left, lastDirection);

                if(lastAngle >= -45 && lastAngle <= 45)
                {
                    dirAngle = DirectionAngle.North;
                }
                else if(45 < lastAngle && lastAngle < 135 && correctionAngle > 90)
                {
                    dirAngle = DirectionAngle.Est;
                }
                else if(45 < lastAngle && lastAngle < 135 && correctionAngle < 90)
                {
                    dirAngle = DirectionAngle.West;
                }
                else
                {
                    dirAngle = DirectionAngle.South;
                }

                //Debug.Log(lastAngle.ToString() + dirAngle.ToString());


                
            }
            else
            {

            }

            if (!isInRoll)
            {
                rollDirection = lastDirection;
            }
        }

        void Move()
        {
            if (!isInRoll && !isFlashing)
            {
                if (!isCrouching && !isPushingObject)
                {
                    targetSpeed = Vector2.ClampMagnitude(lStick, 1) * speed;
                    if(isInBuildup)
                    {
                        animationIndex = 2;
                    }
                    else if(isFlashing)
                    {
                        animationIndex = 3;
                    }
                    else if(isInImmunity)
                    {
                        animationIndex = 8;
                    }
                    else
                    { 
                        animationIndex = 1;
                    }
                }
                else
                {
                    targetSpeed = Vector2.ClampMagnitude(lStick, 1) * crouchSpeed;
                    if(isCrouching)
                    {
                        animationIndex = 5;
                    }
                    else if (isPushingObject)
                    {
                        animationIndex = 1;
                        //si tu veux mettre un son d'objet qu'on pousse c'est ici
                    }
                }
            }


            if (!isInRecoil && !isFlashing)
            {
                currentSpeed.x = Mathf.SmoothDamp(currentSpeed.x, targetSpeed.x, ref xVelocity, accelerationTime);
                currentSpeed.y = Mathf.SmoothDamp(currentSpeed.y, targetSpeed.y, ref yVelocity, accelerationTime);

            }

            collisionLeft = left.isCollision;
            collisionRight = right.isCollision;
            collisionTop = top.isCollision;
            collisionBottom = bottom.isCollision;

            if (collisionLeft && currentSpeed.x < 0)
            {
                currentSpeed.x = 0;
            }
            if (collisionRight && currentSpeed.x > 0)
            {
                currentSpeed.x = 0;
            }
            if (collisionTop && currentSpeed.y > 0)
            {
                currentSpeed.y = 0;
            }
            if (collisionBottom && currentSpeed.y < 0)
            {
                currentSpeed.y = 0;
            }

            if (currentSpeed.magnitude < 0.05)
            {
                dust.Pause();
                dust.Clear();
                if (isInBuildup)
                {
                    animationIndex = 2;
                }
                else if (isFlashing)
                {
                    animationIndex = 3;
                }
                else if (!isCrouching)
                {
                    animationIndex = 0;

                }
                else if (isPushingObject)
                {
                    animationIndex = 9;
                }
                else
                {
                    animationIndex = 7;
                }
                
            }
            else
            {
                dust.Play();
            }
            if(!isFlashing)
            {
                rigidBody.velocity = currentSpeed;

            }
            else
            {
                rigidBody.velocity = Vector2.zero;

            }

            

        }

        void Collisions()
        {
            collisionLeft = left.isCollision;
            collisionRight = right.isCollision;
            collisionTop = top.isCollision;
            collisionBottom = bottom.isCollision;

            Vector3 knockbackSpeed = rigidBody.velocity;

            if (collisionLeft && knockbackSpeed.x < 0)
            {
                knockbackSpeed.x = 0;
            }
            if (collisionRight && knockbackSpeed.x > 0)
            {
                knockbackSpeed.x = 0;
            }
            if (collisionTop && knockbackSpeed.y > 0)
            {
                knockbackSpeed.y = 0;
            }
            if (collisionBottom && knockbackSpeed.y < 0)
            {
                knockbackSpeed.y = 0;
            }

            rigidBody.velocity = knockbackSpeed;

        }

        void Crouch()
        {
            if(!isFlashing && !isInRoll && !isInRecover && !isPushingObject && !isInAttack)   
            {
                isCrouching = !isCrouching;
                //changement mode anim debout accroupi
                //son

                if (isCrouching)
                {
                    Debug.Log("s Crouching !");

                    animationIndex = 5;
                    //indique aux collisions détectors d'ignorer le layer crouchable 
                    //détection des ennemis baisse

                }
            }
        }

        void Roll()
        {
            if (!isInRecover && !isPushingObject && !isCrouching && !isInDialogue)
            {
                isInRoll = true;
                isInImmunity = true;
                isInRecover = true;

                animationIndex = 4;
                StartCoroutine(RollCoroutine());
            }
        }

        IEnumerator RollCoroutine()
        {
            targetSpeed = rollDirection * rollSpeed;
            //anim roulade
            //son roulade
            yield return new WaitForSeconds(rollDuration);
            isInRoll = false;
            isInImmunity = false;
            yield return new WaitForSeconds(rollRecover);
            isInRecover = false;
        }


        void Attack(JUB_Combat.AttackProfile attackProfile)
        {
            Vector2 attackVector = Vector2.zero;
            if (!isInRecover && !isInBuildup && !isInRoll && !isCrouching && !isPushingObject && !isFlashing)
            {
                ennemiesHitLastTime.Clear();
                animationIndex = 2;

                switch (dirAngle)
                {
                    case DirectionAngle.North:
                        attackVector = Vector2.up;
                        break;

                    case DirectionAngle.West:
                        attackVector = Vector2.left;
                        break;

                    case DirectionAngle.Est:
                        attackVector = Vector2.right;
                        break;

                    case DirectionAngle.South:
                        attackVector = Vector2.down;
                        break;
                }
                isInBuildup = true;
                attackProfile.atkVector = attackVector;
                StartCoroutine(Buildup(attackProfile));

                Debug.Log(attackProfile.atkName);
            }
        }

        IEnumerator Buildup(JUB_Combat.AttackProfile attackProfile)
        {
            yield return new WaitForSeconds(attackProfile.atkBuildup);
            isInBuildup = false;
            isInRecover = true;
            //son attaque
            if(attackProfile.atkName == "quick")
            {
                FindObjectOfType<AudioManager>().Play("AttaqueFaible");
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("AttaqueForte");
            }

            StartCoroutine(Hit(attackProfile));
        }
        IEnumerator Hit(JUB_Combat.AttackProfile attackProfile)
        {
            Collider2D[] hitEnnemies = Physics2D.OverlapCircleAll(transform.position, attackProfile.atkZone.x, ennemies);
            Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, attackProfile.atkZone.x, breakableObjects);
            Collider2D[] hitBoss = Physics2D.OverlapCircleAll(transform.position, attackProfile.atkZone.x, bossJewel);

            if (!ennemyWasHitOnce)
            {
                foreach (Collider2D ennemy in hitEnnemies)
                {
                    if (!ennemiesHitLastTime.Contains(ennemy))
                    {
                        Debug.Log(ennemy.bounds.extents.magnitude);
                        Vector2 ennemyDirection = ennemy.transform.position - transform.position;
                        float ennemyAngle = Vector2.Angle(attackProfile.atkVector, ennemyDirection);
                        float a = ennemyDirection.magnitude;
                        float b = ennemyDirection.magnitude;
                        float c = ennemy.bounds.extents.x * 2;
                        float additionalAngle = Mathf.Rad2Deg * Mathf.Acos(((a * a) + (b * b) - (c * c)) / (2 * (a * b)));
                        float totalAngle = attackProfile.atkZone.y + additionalAngle;
                        //Debug.Log("Additional Angle = " + additionalAngle + " / AA+AtkAngle = " + totalAngle + " / Ennemy Angle = " + ennemyAngle);
                        if (ennemyAngle <= totalAngle)
                        {
                            if (ennemy.GetComponent<JUB_EnnemyDamage>())
                            {
                                ennemy.GetComponent<JUB_EnnemyDamage>().TakeDamage(attackProfile.atkDamage);
                                StartCoroutine(CameraShake(screenshakeDuration, ennemyScreenshakeAmount));
                                Debug.Log("attack was performed");
                                ennemiesHitLastTime.Add(ennemy);

                            }

                        }
                    }
                }

            }

            foreach (Collider2D breakableObject in hitObjects)
            {
                breakableObject.GetComponent<JUB_BreakableBehavior>().Breaking();
            }

            foreach(Collider2D jewel in hitBoss)
            {
                jewel.GetComponentInParent<JUB_BossBehavior>().TakeDamage();
                StartCoroutine(CameraShake(screenshakeDuration, bossScreenshakeAmount));
            }

            yield return new WaitForSeconds(attackProfile.atkRecover);
            isInRecover = false;
        }

        IEnumerator CameraShake(float duration, float magnitude)
        {
            Vector2 originalPos = mainCam.transform.localPosition;

            float elapsed = 0f;

            while (elapsed < duration)
            {
                float x = UnityEngine.Random.Range(-1f, 1f) * magnitude;
                float y = UnityEngine.Random.Range(-1f, 1f) * magnitude;
                mainCam.transform.localPosition = new Vector2(x, y);

                elapsed += Time.deltaTime;

                yield return null;
            }

            mainCam.transform.localPosition = originalPos;
        }

        private void OnDrawGizmosSelected()
        {
            if (attackPoint == null)
                return;

            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, quickAtkZone.x);
            Vector3 attackLength;
            attackLength = new Vector3(quickAtkZone.x, 0);
            attackLength = Quaternion.Euler(0, 0, quickAtkZone.y) * attackLength;
            Gizmos.DrawLine(transform.position, transform.position + attackLength);
            attackLength = Quaternion.Euler(0, 0, -2 * quickAtkZone.y) * attackLength;
            Gizmos.DrawLine(transform.position, transform.position + attackLength);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, heavyAtkZone.x);
            attackLength = new Vector3(heavyAtkZone.x, 0);
            attackLength = Quaternion.Euler(0, 0, heavyAtkZone.y) * attackLength;
            Gizmos.DrawLine(transform.position, transform.position + attackLength);
            attackLength = Quaternion.Euler(0, 0, -2 * heavyAtkZone.y) * attackLength;
            Gizmos.DrawLine(transform.position, transform.position + attackLength);

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, interactAndPushableRange);
        }


        void InteractSphere()
        {
            allInteractibleInRange = Physics2D.OverlapCircleAll(transform.position, interactAndPushableRange, interactibleObjects);
            foreach(Collider2D interactible in allInteractibleInRange)
            {
                interactible.GetComponent<JUB_InteractibleBehavior>().interactible = true;
            }
        }

        void Interact()
        {
            Debug.Log("input was done");
            if(!allInteractibleInRange.Count().Equals(0) && !isInRoll && !isInAttack && !isFlashing && !isInDialogue)
            {
                if(allInteractibleInRange.Count().Equals(1))
                {
                    if(allInteractibleInRange.Count().Equals(1))
                    {
                        allInteractibleInRange[0].GetComponent<JUB_InteractibleBehavior>().interacted = true;
                    }
                    else
                    {
                        float smallestAngle = Mathf.Infinity;
                        Collider2D interactibleTarget = allInteractibleInRange[0];
                        foreach(Collider2D interactible in allInteractibleInRange)
                        {
                            Vector2 playerToInteractible = interactible.transform.position - transform.position;
                            float interactibleAngle = Vector2.Angle(lastDirection, playerToInteractible);
                            if(interactibleAngle < smallestAngle)
                            {
                                interactibleTarget = interactible;
                                smallestAngle = interactibleAngle;
                            }
                        }
                        interactibleTarget.GetComponent<JUB_InteractibleBehavior>().interacted = true;
                        Debug.Log(interactibleTarget.name);
                    }
                }
            }
        }

        void PushableSphere()
        {
            allPushableInRange = Physics2D.OverlapCircleAll(transform.position, interactAndPushableRange, pushableObjects);
            foreach(Collider2D pushable in allPushableInRange)
            {
                pushable.GetComponent<JUB_PushableBehavior>().pushable = true;
            }
            if(allPushableInRange.Length == 0)
            {
                isPushingObject = false;
            }
        }
        void PushObjects()
        {
            if (!isFlashing && !isCrouching && !isInAttack && !isInRoll)
            {
                
                if (!allPushableInRange.Count().Equals(0) && !isPushingObject)
                {
                    isPushingObject = true;
                    if (allPushableInRange.Count().Equals(1))
                    {
                        allPushableInRange[0].GetComponent<JUB_PushableBehavior>().pushed = true;
                        allPushableInRange[0].GetComponent<JUB_PushableBehavior>().ManagePushing();
                        Vector2 positionBox = (allPushableInRange[0].transform.position - transform.position).normalized;
                        if(positionBox.x > 0.5)
                        {
                            dirObject = DirectionObject.Est;
                        }
                        else if(positionBox.x < -0.5)
                        {
                            dirObject = DirectionObject.West;
                        }
                        else if(positionBox.y > 0.5)
                        {
                            dirObject = DirectionObject.North;
                        }
                        else if(positionBox.y < -0.5)
                        {
                            dirObject = DirectionObject.South;
                        }
                    }
                    else
                    {
                        float smallestAngle = Mathf.Infinity;
                        Collider2D pushableTarget = allPushableInRange[0];
                        foreach (Collider2D pushable in allPushableInRange)
                        {
                            Vector2 playerToPushable = pushable.transform.position - transform.position;
                            float interactibleAngle = Vector2.Angle(lastDirection, playerToPushable);
                            if (interactibleAngle < smallestAngle)
                            {
                                pushableTarget = pushable;
                                smallestAngle = interactibleAngle;
                            }
                        }
                        pushableTarget.GetComponent<JUB_PushableBehavior>().pushed = true;
                        pushableTarget.GetComponent<JUB_PushableBehavior>().ManagePushing();
                        Vector2 positionBox = (pushableTarget.transform.position - transform.position).normalized;
                        if (positionBox.x > 0.5)
                        {
                            dirObject = DirectionObject.Est;
                        }
                        else if (positionBox.x < -0.5)
                        {
                            dirObject = DirectionObject.West;
                        }
                        else if (positionBox.y > 0.5)
                        {
                            dirObject = DirectionObject.North;
                        }
                        else if (positionBox.y < -0.5)
                        {
                            dirObject = DirectionObject.South;
                        }
                    }
                }
                else if (isPushingObject == true)
                {
                    foreach (Collider2D pushable in allPushableInRange)
                    {
                        isPushingObject = false;
                        pushable.GetComponent<JUB_PushableBehavior>().pushed = false;
                        pushable.GetComponent<JUB_PushableBehavior>().ManagePushing();
                    }
                }
                Debug.Log(isPushingObject.ToString());
            }

            //inverser le booléen

            //si isPush = true mettre l'objet en parent
            //agrandir le box collider du joueur pour qu'il s'ajoute celui de l'objet

            //si !isPush = enlever le parent
            //reduire le collider du joueur à son état d'origine
        }

        //fonctions liées au HUD

        public void TakeDamages(int damages, Vector3 monsterPosition)
        {
            if (!isInImmunity)
            {
                currentLife -= damages;
                //son dégâts
                FindObjectOfType<AudioManager>().Play("CoupsJoueur");
                if (currentLife <= 0)
                {
                    currentLife = 0;
                    Die();
                }
                Knockback(monsterPosition);
                Immunity(immunityTime);
                StopCoroutine(RedFrameCoroutine());
                StartCoroutine(RedFrameCoroutine());
            }
        }

        public void Knockback(Vector3 monsterPosition)
        {
            isInKnockback = true;
            Vector2 direction = (monsterPosition - this.transform.position).normalized;
            Debug.LogWarning("position" + direction);
            rigidBody.velocity = (-direction * knockbackForce);
            StartCoroutine(KnockbackCoroutine());
        }

        IEnumerator KnockbackCoroutine()
        {
            yield return new WaitForSeconds(knockbackDuration);
            Debug.LogWarning(rigidBody.velocity);
            rigidBody.velocity = Vector2.zero;
            isInKnockback = false;
        }



        public void Immunity(float immuTime)
        {
            animationIndex = 8;
            StartCoroutine(ImmunityCoroutine(immuTime));
        }

        IEnumerator ImmunityCoroutine(float immuTime)
        {
            isInImmunity = true;
            yield return new WaitForSeconds(immuTime);
            isInImmunity = false;
        }

        IEnumerator RedFrameCoroutine()
        {
            Color originalColor = this.rendererMaeve.material.color;
            this.rendererMaeve.material.color = Color.Lerp(rendererMaeve.material.color, Color.red, 0.8f);
            yield return new WaitForSeconds(timeRed);
            this.rendererMaeve.material.color = originalColor;

        }

        public void Heal(int heal)
        {
            currentLife += heal;
            if (currentLife > maxLife)
            {
                currentLife = maxLife;
            }
        }

        public void MaxUpgrades(int upgrade)
        {
            maxLife += upgrade;
            currentLife += maxLife;
        }

        void Die()
        {
            deathParticles.Play();
            //son de mort
            FindObjectOfType<AudioManager>().Play("MortJoueur");
            StartCoroutine(DeathCoroutine());
            //respawn checkpoint
        }

        IEnumerator DeathCoroutine()
        {
            yield return new WaitForSeconds(deathAnimDuration);
            deathParticles.Stop();
            deathCanvas.SetActive(true);
           
        }

        public void Respawn()
        {
            deathCanvas.SetActive(false);
            this.gameObject.transform.position = actualCheckpoint.position;
            Heal(maxLife);
            Immunity(immunityTime);
        }

        public void Quit()
        {
            deathCanvas.SetActive(false);
            Destroy(this.gameObject);
            Application.Quit();
        }

        public void GainBonbons(int bonbons)
        {
            paquetBonbons.transform.localScale = paquetOriginalScale * 1.2f;
            //son gain bonbons
            FindObjectOfType<AudioManager>().Play("Bonbons");
            currentBonbons += bonbons;
            StartCoroutine(PaquetNormal());
            displayBonbons.text = currentBonbons.ToString();
        }

        IEnumerator PaquetNormal()
        {
            yield return new WaitForSeconds(0.1f);
            paquetBonbons.transform.localScale = paquetOriginalScale;
        }

        public void Achat(int price)
        {
            currentBonbons -= price;
            //son achat
            displayBonbons.text = currentBonbons.ToString();
        }

       private void OnTriggerEnter2D(Collider2D collision)
        {
            //Debug.LogWarning("touché" + collision.tag.ToString());
            if (collision.CompareTag("Heal"))
            {
                FindObjectOfType<AudioManager>().Play("Coeur");
                Heal(collision.GetComponent<RPP_CollectibleScript>().collectibleValeur);
                collision.GetComponent<RPP_CollectibleScript>().DestroyCollectible();
            }

            if (collision.CompareTag("HealthBoost"))
            {
                MaxUpgrades(collision.GetComponent<RPP_CollectibleScript>().collectibleValeur);
                collision.GetComponent<RPP_CollectibleScript>().DestroyCollectible();
            }

            if (collision.CompareTag("Bonbon"))
            {
                GainBonbons(collision.GetComponent<RPP_CollectibleScript>().collectibleValeur);
                collision.GetComponent<RPP_CollectibleScript>().DestroyCollectible();
            }

            if (collision.CompareTag("DamageDealer"))
            {
                TakeDamages(collision.GetComponent<JUB_DamagingEvent>().damageAmount, collision.transform.position);
            }
        }

        public void Anim()
        {
            if (animationIndex == 3)
            {
                shaderFlame.SetActive(true);
            }
            else
            {
                shaderFlame.SetActive(false);
            }
            if (isInRoll)
            {
                animationIndex = 4;
            }
            if (!isPushingObject)
            {
                switch (dirAngle)
                {
                    case DirectionAngle.North:
                        animationIndex += 100;
                        break;

                    case DirectionAngle.Est:
                        animationIndex += 200;
                        break;

                    case DirectionAngle.South:
                        animationIndex += 300;
                        break;

                    case DirectionAngle.West:
                        animationIndex += 400;
                        break;
                }
            }
            else
            {
                switch(dirObject)
                {
                    case DirectionObject.North:
                        animationIndex += 100;
                        break;

                    case DirectionObject.Est:
                        animationIndex += 200;
                        break;

                    case DirectionObject.West:
                        animationIndex += 400;
                        break;

                    case DirectionObject.South:
                        animationIndex += 300;
                        break;
                }
            }

            
            
            switch(animationIndex)
            {
                //-1 mort, 0 idle, 1 course, 2 attaque, 3 flash, 4 roulade, 5 accroupi, 6 déplacement objet, 7 accroupi iddle, 8 immunité, 9 pushIdle

                //idle
                case 100:
                    maeveAnimator.Play("Maeve_idle_back");
                    break;

                case 200:
                    maeveAnimator.Play("Maeve_idle_right");
                    break;

                case 300:
                    maeveAnimator.Play("Maeve_idle_front");
                    break;

                case 400:
                    maeveAnimator.Play("Maeve_idle_left");
                    break;

                //run
                case 101:
                    maeveAnimator.Play("Maeve_run_back");
                    break;

                case 201:
                    maeveAnimator.Play("Maeve_run_right");
                    break;

                case 301:
                    maeveAnimator.Play("Maeve_run_front");
                    break;

                case 401:
                    maeveAnimator.Play("Maeve_run_left");
                    break;

                //attack
                case 102:
                    maeveAnimator.Play("Maeve_attack_back");
                    break;

                case 202:
                    maeveAnimator.Play("Maeve_attack_right");
                    break;

                case 302:
                    maeveAnimator.Play("Maeve_attack_front");
                    break;

                case 402:
                    maeveAnimator.Play("Maeve_attack_left");
                    break;

                //flash
                case 103:
                    maeveAnimator.Play("Maeve_burn_back");
                    break;

                case 203:
                    maeveAnimator.Play("Maeve_burn_right");
                    break;

                case 303:
                    maeveAnimator.Play("Maeve_burn_front");
                    break;

                case 403:
                    maeveAnimator.Play("Maeve_burn_left");
                    break;

                //roulade
                case 104:
                    maeveAnimator.Play("Maeve_roulade_back");
                    break;

                case 204:
                    maeveAnimator.Play("Maeve_roulade_right");
                    break;

                case 304:
                    maeveAnimator.Play("Maeve_roulade_front");
                    break;

                case 404:
                    maeveAnimator.Play("Maeve_roulade_left");
                    break;

                //accroupi
                case 105:
                    maeveAnimator.Play("Maeve_accroupie_back");
                    break;

                case 205:
                    maeveAnimator.Play("Maeve_accroupie_right");
                    break;

                case 305:
                    maeveAnimator.Play("Maeve_accroupie_front");
                    break;

                case 405:
                    maeveAnimator.Play("Maeve_accroupie_left");
                    break;

                //déplacement objet
                case 106:
                    maeveAnimator.Play("Maeve_obj_back");
                    break;

                case 206:
                    maeveAnimator.Play("Maeve_obj_right");
                    break;

                case 306:
                    maeveAnimator.Play("Maeve_obj_front");
                    break;

                case 406:
                    maeveAnimator.Play("Maeve_obj_left");
                    break;

                //accroupi idle
                case 107:
                    maeveAnimator.Play("Maeve_accroupieIdle_back");
                    break;

                case 207:
                    maeveAnimator.Play("Maeve_accroupieIdle_right");
                    break;

                case 307:
                    maeveAnimator.Play("Maeve_accroupieIdle_front");
                    break;

                case 407:
                    maeveAnimator.Play("Maeve_accroupieIdle_left");
                    break;

                //immunité
                case 108:
                    maeveAnimator.Play("Maeve_hurt_back");
                    break;

                case 208:
                    maeveAnimator.Play("Maeve_hurt_right");
                    break;

                case 308:
                    maeveAnimator.Play("Maeve_hurt_front");
                    break;

                case 408:
                    maeveAnimator.Play("Maeve_hurt_left");
                    break;

                //push idle
                case 109:
                    maeveAnimator.Play("Maeve_objIdle_back");
                    break;

                case 209:
                    maeveAnimator.Play("Maeve_objIdle_right");
                    break;

                case 309:
                    maeveAnimator.Play("Maeve_objIdle_front");
                    break;

                case 409:
                    maeveAnimator.Play("Maeve_objIdle_left");
                    break;

            }
            //Debug.LogWarning(animationIndex);
            animationIndex = 0;

            
                
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using character;

public class JUB_BossBehavior : MonoBehaviour
{
    public Animator SMBanimator;
    public int bossHitNumber = 0;
    public bool isInCombat;
    public bool canBeFlashed, isFlashed;
    public LayerMask playerLayer;
    public JUB_Maeve maeve;

    public float immunityTime;
    public bool isInImmunity;

    //attack paw
    public Collider2D pawCollider, pawAttackZone; //paw attack zone doit être sur l'objet qui contient ce script //paw collider sur un enfant
    public float flashRecoveryTime;
    public float buildupTime, recoveryTime, hitspanTime;
    public int pawDamages = 3;

    //attack spawn
    public GameObject spawningTrap;
    public int numberTrapPhase1, numberTrapPhase2, numberTrapPhase3;
    public Vector2 centerOfArea, sizeOfArea;
    public float timeBetweenTwo;

    //iddle elements
    public float timeBetweenAttacks;
    public Collider2D collierCollider; //un objet en enfant avec layer PointSensibleBoss 

    //flash elements
    public JUB_FlashManager flashManager, tailFlashManager; //pas sur le même objet évidemment
    public float timeBetweenTwoEyeBlinks;

    //burn tail elements
    public bool tailWasBurned;
    public float timeBurning;

    //anim
    public Animator graphicAnimator;
    public SpriteRenderer bossRenderer;
    Color originalColor;
    public float startAnimationTime = 1f, timered;
    public bool isInAttack, isBurned, isBlinking;

    // Start is called before the first frame update
    void Start()
    {
        maeve = GameObject.FindGameObjectWithTag("Player").GetComponent<JUB_Maeve>();

        SMBanimator.GetBehaviour<BossSMB_Iddle>().boss = this;
        SMBanimator.GetBehaviour<BossSMB_PawAttack>().boss = this;
        SMBanimator.GetBehaviour<BossSMB_SpawnObject>().boss = this;

        canBeFlashed = true;

        originalColor = this.bossRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(bossHitNumber == 0)
        {
            if (!isInAttack && !isFlashed)
            {
                SetAnimation(0);
            }
        }
        else if(bossHitNumber == 1 && !isBlinking)
        {
            isBlinking = true;
            StartCoroutine(EyesClosingCoroutine()); //coroutine d'ouverture et de fermeture d'yeux
        }

        if(tailFlashManager.burned && bossHitNumber >= 2)
        {
            isBurned = true;
            canBeFlashed = true;
            StartCoroutine(BurnTailRecovery()); //celui ci doit lancer le compteur de temps avant que la queue ne soit plus brulée
        }

        if(canBeFlashed && flashManager.flashed)
        {
            isFlashed = true; //empeche l'attaque de pattes
            StartCoroutine(FlashRecovery()); //recovery du flash
        }

        if(bossHitNumber >= 2 && !isBurned && !isFlashed && !isInAttack)
        {
            SetAnimation(3);
        }
    }

    public void TakeDamage()
    {
        if (!isInImmunity)
        {
            bossHitNumber++;
            isInImmunity = true;
            StartCoroutine(ImmunityAttacked());
            StartCoroutine(TimeRedCoroutine());
            if (bossHitNumber == 2)
            {
                canBeFlashed = false;
                
            }
            if (bossHitNumber >= 3)
            {
                EndBattle();
            }

        }
    }

    IEnumerator TimeRedCoroutine()
    {
        this.bossRenderer.color = Color.Lerp(originalColor, Color.red, 0.8f);
        yield return new WaitForSeconds(timered);
        this.bossRenderer.color = originalColor;
    }
    

    void EndBattle()
    {
        isInCombat = false;
        SetAnimation(-1);
        //Time.timeScale = 0f;
        //lancer dialogue
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !isFlashed)
        {
            SMBanimator.Play("PawAttack");
        }
    }

    IEnumerator FlashRecovery()
    {
        SetAnimation(5);
        yield return new WaitForSeconds(flashRecoveryTime);
        isFlashed = false;
    }

    IEnumerator BurnTailRecovery()
    {
        SetAnimation(6);
        yield return new WaitForSeconds(timeBurning);
        canBeFlashed = false;
        isBurned = false;
    }

    IEnumerator EyesClosingCoroutine()
    {
        Debug.LogWarning("should blink");
        yield return new WaitForSeconds(timeBetweenTwoEyeBlinks);
        canBeFlashed = !canBeFlashed;
        if (!isInAttack && !isFlashed)
        {
            if (canBeFlashed == true)
            {
                SetAnimation(2);
            }
            else
            {
                SetAnimation(1);
            }
            isBlinking = false;
        }

        //faudra bien vérifier vis à vis de l'anim et régler à l'entrée de l'état
    }

    IEnumerator ImmunityAttacked()
    {
        yield return new WaitForSeconds(immunityTime);
        isInImmunity = false;
    }

    public void StartFight()
    {
        SetAnimation(-2);
        StartCoroutine(StartFightCoroutine());

    }

    IEnumerator StartFightCoroutine()
    {
        yield return new WaitForSeconds(startAnimationTime);
        isInCombat = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(centerOfArea, sizeOfArea);
    }

    public void SetAnimation(int anim)
    {
        //-2 assis, -1 mort, 0 idle yeux ouverts, 1 idle yeux fermés, 2 idle un oeil, 3 idle queue au sol, 4 attaque, 5 stun, 6 burn
        switch (anim)
        {
            case -2:
                graphicAnimator.Play("boss_laydown");
                break;

            case -1:
                graphicAnimator.Play("boss_death");
                break;

            case 0:
                graphicAnimator.Play("boss_idle");
                break;

            case 1:
                graphicAnimator.Play("boss_idle_tailup");
                break;

            case 2:
                graphicAnimator.Play("boss_idle_oneye");
                break;

            case 3:
                graphicAnimator.Play("boss_idle_taildown");
                break;

            case 4:
                graphicAnimator.Play("boss_idle_attacks");
                break;

            case 5:
                graphicAnimator.Play("boss_hit");
                break;

            case 6:
                graphicAnimator.Play("boss_burn");
                break;
        }
    }
}

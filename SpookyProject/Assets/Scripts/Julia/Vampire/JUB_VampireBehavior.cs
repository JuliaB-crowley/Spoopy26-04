using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using character;

public class JUB_VampireBehavior : MonoBehaviour
{
    public Animator SMBanimator;
    public AIPath pathfinder;
    public AIDestinationSetter destinationSetter;
    public JUB_Maeve player;
    public JUB_EnnemyDamage ennemyDamage;

    //sight cast parameters 
    public float maxSight;
    public Vector2 toPlayer;
    public LayerMask blocksLOS, isPlayer;
    public bool playerInSight, playerInMemory;
    public float timeBeforeForget, secondSinceLastSeen;

    //iddle elements
    public bool cyclicPatrol = false;
    public List<Transform> patrolTargets = new List<Transform>();
    public float patrolWaitTime, iddleSpeed;

    //pursue elements
    public float stopDistance, pursueSpeed;

    //pause elements
    public float pauseTime;

    //flee elements
    public float securityThreshold, fleeDistance, fleeSpeed;
    public bool isEscaping;

    //attack elements
    public GameObject batPrefab;
    public float buildupTime, recoveryTime;

    //stun elements
    public float stunTime;
    public JUB_FlashManager flashManager;
    public bool hasBeenStunned;

    //anim 
    public Animator graphicAnimator;
    public float animTransformTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<JUB_Maeve>();
        SMBanimator = GetComponent<Animator>();
        pathfinder = GetComponent<AIPath>();
        destinationSetter = GetComponent<AIDestinationSetter>();
        flashManager = GetComponentInChildren<JUB_FlashManager>();
        ennemyDamage = GetComponent<JUB_EnnemyDamage>();

        SMBanimator.GetBehaviour<VampireSMB_Idle>().vampire = this;
        SMBanimator.GetBehaviour<VampireSMB_Attack>().vampire = this;
        SMBanimator.GetBehaviour<VampireSMB_Escape>().vampire = this;
        SMBanimator.GetBehaviour<VampireSMB_Stun>().vampire = this;
        SMBanimator.GetBehaviour<VampireSMB_Pause>().vampire = this;
        SMBanimator.GetBehaviour<VampireSMB_Pursue>().vampire = this;
    }

    // Update is called once per frame
    void Update()
    {
        toPlayer = player.transform.position - transform.position;
        Vector2 distanceFromPlayer = toPlayer;
        toPlayer.Normalize();
        SightCast();
        if (!playerInSight)
        {
            MemoryTime();

        }

        if((distanceFromPlayer.magnitude < securityThreshold) && !isEscaping && !hasBeenStunned)
        {
            isEscaping = true;
            SetAnimation(3);
            StartCoroutine(TransformAnim());
        }

        if(flashManager.flashed && !hasBeenStunned)
        {
            hasBeenStunned = true;
            SMBanimator.Play("Stun");
        }
        if (ennemyDamage.currentHealth == 0)
        {
            SetAnimation(-1);
        }
    }

    IEnumerator TransformAnim()
    {
        yield return new WaitForSeconds(animTransformTime);
        SMBanimator.Play("Escape");
    }
    void SightCast()
    {
        RaycastHit2D hit2D;
        //RaycastHit hit;
        float hitLength = maxSight;
        if (player.isCrouching)
        {
            hitLength /= 2;
        }
        hit2D = Physics2D.Raycast(transform.position, toPlayer, hitLength, blocksLOS);
        //Physics.Raycast(transform.position, toPlayer, out hit, hitLength, blocksLOS);
        if (hit2D.collider)
        {
            hitLength = hit2D.distance;
        }



        hit2D = Physics2D.Raycast(transform.position, toPlayer, hitLength, isPlayer);
        if (hit2D.collider)
        {
            playerInSight = true;
            hitLength = hit2D.distance;
            playerInMemory = true;
            secondSinceLastSeen = 0;
        }
        else
        {
            playerInSight = false;
        }

        Debug.DrawRay(transform.position, toPlayer * hitLength, Color.red);



    }

    void MemoryTime()
    {
        secondSinceLastSeen += Time.deltaTime;
        if (secondSinceLastSeen >= timeBeforeForget)
        {
            playerInMemory = false;
            secondSinceLastSeen = 0;
        }
    }

    public void SetAnimation(int anim)
    {
        //-1 ded, 0 idle, 1 invoc, 2 stun, 3 transformation, 4 chauve souris form

        string animToPlay = "Vamp_idle_déplacement";
        switch (anim)
        {
            case -1:
                animToPlay = "Vamp_mort";
                break;

            case 0:
                animToPlay = "Vamp_idle_déplacement";
                break;

            case 1:
                animToPlay = "Vamp_invocation";
                break;

            case 2:
                animToPlay = "Vamp_stun";
                break;

            case 3:
                animToPlay = "Vamp_transformation";
                break;

            case 4:
                animToPlay = "Chauvesouris_transformation";
                break;
        }
        if (anim == 0)
        {
            int direction = 3; //0 = rigth, 1 = left, 2 = up, 3 = down
            if (pathfinder.velocity.normalized.x > 0.5)
            {
                direction = 0;
            }
            else if (pathfinder.velocity.normalized.x < -0.5)
            {
                direction = 1;
            }
            else if (pathfinder.velocity.normalized.y > 0.5)
            {
                direction = 2;
            }
            else if (pathfinder.velocity.normalized.y < -0.5)
            {
                direction = 3;
            }
            switch (direction)
            {
                case 0:
                    animToPlay += "_right";
                    break;

                case 1:
                    animToPlay += "_left";
                    break;

                case 2:
                    animToPlay += "_back";
                    break;

                case 3:
                    animToPlay += "_front";
                    break;
            }
        }
        graphicAnimator.Play(animToPlay);
    }

}

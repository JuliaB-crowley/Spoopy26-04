using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using character;

public class JUB_ImpBehavior : MonoBehaviour
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

    //strint elements
    public float sprintDistance, sprintSpeed, instantiationTime;
    public GameObject damageTrail;
    public bool isAttacking;
    float timeSinceInstantiated;

    //pause elements
    public float pauseTime;

    //stun elements
    public float stunTime;
    public JUB_FlashManager flashManager;
    public bool hasBeenStunned;

    //animation parameters
    public Animator graphicAnimator;


    // Start is called before the first frame update
    void Start()
    {
        instantiationTime = (sprintDistance / sprintSpeed)/7;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<JUB_Maeve>();
        flashManager = GetComponentInChildren<JUB_FlashManager>();
        SMBanimator = GetComponent<Animator>();
        pathfinder = GetComponent<AIPath>();
        destinationSetter = GetComponent<AIDestinationSetter>();
        ennemyDamage = GetComponent<JUB_EnnemyDamage>();

        SMBanimator.GetBehaviour<ImpSMB_Idle>().imp = this;
        SMBanimator.GetBehaviour<ImpSMB_Pursue>().imp = this;
        SMBanimator.GetBehaviour<ImpSMB_Sprint>().imp = this;
        SMBanimator.GetBehaviour<ImpSMB_Pause>().imp = this;

        SMBanimator.GetBehaviour<ImpSMB_Stun>().imp = this;
    }

    // Update is called once per frame
    void Update()
    {
        toPlayer = player.transform.position - transform.position;
        toPlayer.Normalize();
        SightCast();
        if(!playerInSight)
        {
            MemoryTime();

        }
        if(isAttacking)
        {
            timeSinceInstantiated += Time.deltaTime;
            if(timeSinceInstantiated >= instantiationTime)
            {
                MakeDamages();
                timeSinceInstantiated = 0;
            }
        }
        if (flashManager.flashed && !hasBeenStunned)
        {
            hasBeenStunned = true;
            SMBanimator.Play("Stun");
        }
        if(ennemyDamage.currentHealth == 0)
        {
            SetAnimation(-1);
        }
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
        if(hit2D.collider)
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
        if(secondSinceLastSeen >= timeBeforeForget)
        {
            playerInMemory = false;
            secondSinceLastSeen = 0;
        }
    }

    void MakeDamages()
    {
        Object.Instantiate(damageTrail).transform.position = transform.position;
    }

    public void SetAnimation(int anim)
    {
        //-1 ded, 0 idle, 1 run, 2 attack, 3 stun

        string animToPlay = "Diablotin_idle";
        switch(anim)
        {
            case -1:
                animToPlay = "Diablotin_death";
                break;

            case 0:
                animToPlay = "Diablotin_idle";
                break;

            case 1:
                animToPlay = "Diablotin_walk";
                break;

            case 2:
                animToPlay = "Diablotin_attack";
                break;

            case 3:
                animToPlay = "Diablotin_hit";
                break;
        }
        int direction = 3; //0 = rigth, 1 = left, 2 = up, 3 = down
        if(pathfinder.velocity.normalized.x > 0.5)
        {
            direction = 0;
        }
        else if(pathfinder.velocity.normalized.x < -0.5)
        {
            direction = 1;
        }
        else if(pathfinder.velocity.normalized.y > 0.5)
        {
            direction = 2;
        }
        else if(pathfinder.velocity.normalized.y < -0.5)
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
        graphicAnimator.Play(animToPlay);
    }

}

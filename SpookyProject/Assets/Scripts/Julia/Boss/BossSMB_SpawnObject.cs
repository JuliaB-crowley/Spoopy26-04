using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSMB_SpawnObject : StateMachineBehaviour
{
    public JUB_BossBehavior boss;
    public float timeBetweenTraps;
    public int numberAlreadySpawned;
    public bool maeveTrapSpawned = false;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        maeveTrapSpawned = false;
        timeBetweenTraps = 0;
        numberAlreadySpawned = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (boss.isInCombat)
        {
            timeBetweenTraps += Time.deltaTime;
            boss.centerOfArea = boss.maeve.transform.position;
            if (maeveTrapSpawned == false)
            {
                maeveTrapSpawned = true;
                Instantiate(boss.spawningTrap, boss.maeve.transform.position, Quaternion.identity);
            }
            if (boss.bossHitNumber == 0)
            {
                if (timeBetweenTraps >= boss.timeBetweenTwo && numberAlreadySpawned <= boss.numberTrapPhase1)
                {
                    timeBetweenTraps = 0;
                    Vector2 pos = boss.centerOfArea + new Vector2(Random.Range(-boss.sizeOfArea.x / 2, boss.sizeOfArea.x / 2), Random.Range(-boss.sizeOfArea.y / 2, boss.sizeOfArea.y / 2));
                    Instantiate(boss.spawningTrap, pos, Quaternion.identity);
                    numberAlreadySpawned++;

                }
                else if (numberAlreadySpawned > boss.numberTrapPhase1)
                {
                    animator.Play("Idle");
                }
            }

            else if (boss.bossHitNumber == 1)
            {
                if (timeBetweenTraps >= boss.timeBetweenTwo && numberAlreadySpawned <= boss.numberTrapPhase2)
                {
                    timeBetweenTraps = 0;
                    Vector2 pos = boss.centerOfArea + new Vector2(Random.Range(-boss.sizeOfArea.x / 2, boss.sizeOfArea.x / 2), Random.Range(-boss.sizeOfArea.y / 2, boss.sizeOfArea.y / 2));
                    Instantiate(boss.spawningTrap, pos, Quaternion.identity);
                    numberAlreadySpawned++;
                }
                else if (numberAlreadySpawned > boss.numberTrapPhase2)
                {
                    animator.Play("Idle");
                }
            }

            else if (boss.bossHitNumber == 2)
            {
                if (timeBetweenTraps >= boss.timeBetweenTwo && numberAlreadySpawned <= boss.numberTrapPhase3)
                {
                    timeBetweenTraps = 0;
                    Vector2 pos = boss.centerOfArea + new Vector2(Random.Range(-boss.sizeOfArea.x / 2, boss.sizeOfArea.x / 2), Random.Range(-boss.sizeOfArea.y / 2, boss.sizeOfArea.y / 2));
                    Instantiate(boss.spawningTrap, pos, Quaternion.identity);
                    numberAlreadySpawned++;

                }
                else if (numberAlreadySpawned > boss.numberTrapPhase3)
                {
                    animator.Play("Idle");
                }
            }
        }
        else
        {
            animator.Play("Idle");
        }
    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeBetweenTraps = 0;
        numberAlreadySpawned = 0;
        maeveTrapSpawned = false;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}

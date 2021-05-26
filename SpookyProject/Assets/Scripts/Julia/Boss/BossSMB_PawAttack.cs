using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSMB_PawAttack : StateMachineBehaviour
{
    public JUB_BossBehavior boss;
    float timeSinceBuildup, timeSinceRecovery, timeSinceHitspan;
    bool isInBuildup, isInRecovery, isInHitspan;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeSinceHitspan = timeSinceBuildup = timeSinceRecovery = 0;
        isInBuildup = true;
        boss.isInAttack = true;
        boss.SetAnimation(4);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (isInBuildup)
        {
            timeSinceBuildup += Time.deltaTime;
            if (timeSinceBuildup >= boss.buildupTime)
            {
                isInHitspan = true;
                isInBuildup = false;
                timeSinceBuildup = timeSinceHitspan = 0;
            }
        }

        if (isInHitspan)
        {
            timeSinceHitspan += Time.deltaTime;
            HitSpan();
            if (timeSinceHitspan >= boss.hitspanTime)
            {
                isInHitspan = false;
                isInRecovery = true;
                timeSinceHitspan = timeSinceRecovery = 0;
            }
        }

        if (isInRecovery)
        {
            timeSinceRecovery += Time.deltaTime;
            if (timeSinceRecovery >= boss.recoveryTime)
            {
                isInRecovery = false;
                timeSinceRecovery = 0;
                animator.Play("Idle");
            }
        }

        void HitSpan()
        {
            if(boss.pawCollider.IsTouchingLayers(boss.playerLayer))
            {
                boss.maeve.TakeDamages(boss.pawDamages);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.isInAttack = false;
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
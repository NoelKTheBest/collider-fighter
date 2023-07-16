using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior_Attack : StateMachineBehaviour
{
    BoxCollider2D hitbox;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //hitbox = animator.GetComponentInChildren<BoxCollider2D>();
        //Debug.Log(hitbox);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //hitbox.offset = new Vector2(1.26f, 0f);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}

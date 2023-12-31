using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior_Idle : StateMachineBehaviour
{
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            animator.SetBool("Running", true);
        }
        
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack");
        }
    }
}

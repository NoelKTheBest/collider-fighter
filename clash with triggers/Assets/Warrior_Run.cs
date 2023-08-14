using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior_Run : StateMachineBehaviour
{
    public float speed = 5f;
    float mirror;

    Rigidbody2D rb;
    SpriteRenderer sr;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.gameObject.name == "Mirror Warrior") mirror = -1f;
        else mirror = 1f;

        rb = animator.GetComponent<Rigidbody2D>();
        sr = animator.GetComponent<SpriteRenderer>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, 0f);
            
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                sr.flipX = false;
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                sr.flipX = true;
            }
        }
        else
        {
            animator.SetBool("Running", false);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.ResetTrigger("Attack");
        rb.velocity = Vector2.zero;
    }
}

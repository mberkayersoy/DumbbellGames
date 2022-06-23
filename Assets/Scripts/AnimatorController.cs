using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    //Instead of controlling the animations in the controller script.
    //I preferred to do it here. As you can see, everything is based on if conditions.
    [SerializeField] Animator animator;

    private void Update()
    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("walk", true);

            if (Input.GetKey(KeyCode.Space)) //Jump if the space is pressed while running.
            {
                animator.SetBool("runningjump", true);
                StartCoroutine(SetFalseJump()); // 
            }

            if (Input.GetKey(KeyCode.LeftShift)) //If shift is pressed while walking, start running.
            {
                animator.SetBool("run", true);

                if (Input.GetKey(KeyCode.Space)) //If space is pressed while running, jump by running.
                {
                    animator.SetBool("runningjump", true);
                    StartCoroutine(SetFalseJump()); //Calling the coroutine function to make the jump animation false.
                }
            }
            else
            {
                animator.SetBool("run", false); 
            }
        }
        else //If the character does not press any key, it will automatically idle.
        {
            animator.SetBool("walk", false);
        }


        if (Input.GetKeyDown(KeyCode.Space)) //Standing jump.
        {
            animator.SetBool("jump", true);
            StartCoroutine(SetFalseJump()); //Calling the coroutine function to make the jump animation false.
        }

    }
    private IEnumerator SetFalseJump() //Standard coroutine function that makes jump animations false.
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("jump", false);
        animator.SetBool("runningjump", false);
    }
}

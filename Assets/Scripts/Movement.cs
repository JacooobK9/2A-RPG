using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetFloat("vertical", Input.GetAxis("Vertical"));
        animator.SetFloat("horizontal", Input.GetAxis("Horizontal"));
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift));


    }

    public void Jump()
    {
        animator.SetTrigger("Jump");
    }
    public void Run()
    {
        animator.SetBool("Run", true);
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("1"))
        {
            animator.SetBool("isWalking", true);
        }
        if (Input.GetKey("2"))
        {
            animator.SetBool("ispunch", true);
        }
        if (Input.GetKey("3"))
        {
            animator.SetBool("isDeath", true);
        }
    }
}

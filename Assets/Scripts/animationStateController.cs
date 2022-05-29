using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    public GameObject player;
    int MinDist = 5;
    Collision2D collision;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        animator.SetBool("isWalking", false);
        animator.SetBool("isPunch", false);
        animator.SetBool("isDeath", false);
    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(player.transform.position);

        if (Vector3.Distance(transform.position, player.transform.position) >= MinDist)
        {
            punch(false);
            animator.SetBool("isWalking", true);
        }
        else
        {
            punch(true);
        }
    }

    void punch(bool pun)
    {
        animator.SetBool("isPunch", pun);
    }
}

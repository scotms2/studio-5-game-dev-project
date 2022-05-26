using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;
    int MinDist = 5;
    Collision2D collision;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsFire", false);

    }

    // Update is called once per frame
    void Update()
    {
    }

    //void OnMouseDown()
    //{
    //animator.SetBool("isDeath", true);
    //}

}

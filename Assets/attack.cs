using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.root.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "playerTrigger")
        {
            
            //animationStateController temp = GetComponent(typeof(animationStateController)) as animationStateController;
            if(animator.GetBool("isPunch"))
            {
                Debug.Log("hit player");
            }
        }
            
    }
}

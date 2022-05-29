using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    Animator animator;
    private HealthSystem healthSystem = new HealthSystem(100);

    public GameObject txtPrefab;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthSystem.GetHealth() <= 0)
        {
            Debug.Log("oooooooo");
            animator.SetBool("isDeath", true);
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("DeathAni"))
            {
                Destroy(gameObject);
            }
            
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("trig");
        if (collider.gameObject.tag == "Fire")
        {
            Debug.Log("Fire Hit");
            healthSystem.Damage(100);
        }
    }
}

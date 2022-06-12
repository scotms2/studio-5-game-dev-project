using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    Animator animator;
    private HealthSystem healthSystem = new HealthSystem(100);

    public GameObject txtPrefab;
    public Slider slider;

    void Start()
    {
        animator = GetComponent<Animator>();
        slider.value = healthSystem.GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = healthSystem.GetHealth();
        if (healthSystem.GetHealth() <= 0)
        {
            animator.SetBool("isDeath", true);
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("dead"))
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
            healthSystem.Damage(1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Animator animator;
    int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        animator = transform.root.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damge(int amount)
    {
        if(health <= 0)
        {
            Debug.Log("Enemy Dead");
            Destroy(gameObject);
        }
        else
        {
            
            health = health - amount;
            Debug.Log("damage dealt " + health);
        }
    }
}

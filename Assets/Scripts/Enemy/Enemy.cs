using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private HealthSystem healthSystem = new HealthSystem(100);

    public GameObject txtPrefab;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(healthSystem.GetHealth() <= 0)
        {
            Destroy(gameObject);
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

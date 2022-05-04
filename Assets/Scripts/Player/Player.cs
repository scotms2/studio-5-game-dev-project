using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI txt;

    private HealthSystem healthSystem = new HealthSystem(100);

    void Start()
    {
        txt.text = "HP: " + healthSystem.GetHealth() + "\\" + healthSystem.GetMaxHealth();
    }

    void Update() 
    {
        txt.text = "HP: " + healthSystem.GetHealth() + "\\" + healthSystem.GetMaxHealth();
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Hand")
        {
            healthSystem.Damage(10);
        }
    }
}

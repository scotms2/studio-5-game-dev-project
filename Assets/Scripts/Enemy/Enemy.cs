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
    }
}

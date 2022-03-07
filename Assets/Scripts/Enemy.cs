using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Spawner enemySpawner;

    public float runSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }

    public void SetSpawner(Spawner spawner)
    {
        enemySpawner = spawner;
    }
}

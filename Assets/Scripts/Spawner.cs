using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToBeSpawned;

    [SerializeField] private int numberOfItems;

    [SerializeField] private float spawnTime;

    [SerializeField] private float spawnDelay;

    [SerializeField] private bool stopSpawning;

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnDelay);
    }

    public void Spawn()
    {
        for (int i = 0; i < numberOfItems; i++)
        {
            Instantiate(objectToBeSpawned, transform.position, transform.rotation);
            if(stopSpawning) {
                CancelInvoke("Spawn");
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Spawner enemySpawner;

    public float runSpeed;

    public GameObject player;

    int MinDist = 5;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);

        transform.LookAt(player.transform.position);

        if (Vector3.Distance(transform.position, player.transform.position) >= MinDist)
        {
            transform.position += transform.forward * runSpeed * Time.deltaTime;
        }
    }

    public void SetSpawner(Spawner spawner)
    {
        enemySpawner = spawner;
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
    }
}

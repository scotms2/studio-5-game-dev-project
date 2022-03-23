using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Spawner enemySpawner;

    public float runSpeed;

    public GameObject player;

    //private NavMeshAgent navMeshAgent;

    int MinDist = 1;

    // void Awake()
    // {
    //     navMeshAgent = GetComponent<NavMeshAgent>();
    // }

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
            //navMeshAgent.destination = player.transform.position;
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

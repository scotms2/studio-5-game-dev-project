using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    private Camera cam;
    
    [SerializeField] private GameObject player;

    private NavMeshAgent agent;

    private Spawner enemySpawner;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(player.transform.position);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            agent.SetDestination(hit.point);
        }
    }

    public void SetSpawner(Spawner spawner)
    {
        enemySpawner = spawner;
    }

}

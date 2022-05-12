using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool canSpawn = true;

    public GameObject enemyPrefab;

    public List<Transform> enemySpawnPositions = new List<Transform>();

    public float timeBetweenSpawns;

    private List<GameObject> enemyList = new List<GameObject>();

    [SerializeField] private Transform parent;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }


    private void SpawnEnemey()
    {
        Vector3 randomPosition = enemySpawnPositions[Random.Range(0, enemySpawnPositions.Count)].position;

        GameObject enemy = Instantiate(enemyPrefab, randomPosition, enemyPrefab.transform.rotation);

        enemyList.Add(enemy);
        enemy.transform.SetParent(parent);

        enemy.GetComponent<EnemyNavMesh>().SetSpawner(this);
    }

    private IEnumerator SpawnRoutine()
    {
        while(canSpawn)
        {
            SpawnEnemey();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    public void RemoveEnemiesFromList(GameObject enemy)
    {
        enemyList.Remove(enemy);
    }

    public void DestroyAllEnemies()
    {
        foreach (GameObject enemy in enemyList)
        {
            Destroy(enemy);
        }

        enemyList.Clear();
    }
}

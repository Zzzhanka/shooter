using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnInterval = 5f;

    private float nextSpawnTime;

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnZombie();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    private void SpawnZombie()
    {
        if (zombiePrefab == null || spawnPoints.Length == 0) return;

        int index = Random.Range(0, spawnPoints.Length);
        Instantiate(zombiePrefab, spawnPoints[index].position, spawnPoints[index].rotation);
    }
}

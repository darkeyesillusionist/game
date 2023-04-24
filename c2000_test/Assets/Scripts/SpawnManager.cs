using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
        public GameObject[] enemyPrefabs;
        public Transform[] spawnPoints;

        // You can set spawn intervals and triggers here
        public float spawnInterval = 5f;

        void Start()
        {
                StartCoroutine(SpawnEnemies());
        }

        IEnumerator SpawnEnemies()
        {
                while (true)
                {
                        foreach (var spawnPoint in spawnPoints)
                        {
                                // Choose a random enemy from the prefabs
                                int enemyIndex = Random.Range(0, enemyPrefabs.Length);

                                // Instantiate the enemy at the spawn point
                                Instantiate(enemyPrefabs[enemyIndex], spawnPoint.position, spawnPoint.rotation);
                        }

                        // Wait for the spawn interval before spawning the next wave
                        yield return new WaitForSeconds(spawnInterval);
                }
        }
}

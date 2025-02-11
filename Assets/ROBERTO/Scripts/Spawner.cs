using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private int rounds;
    [SerializeField] private int spawnsPerRound;
    [SerializeField] private float waitPerSpawns;

    private bool isActive = false;
    private IEnumerator SpawnSystem()
    {
        for (int i = 0; i < rounds; i++)
        {
            for(int j = 0; j < spawnsPerRound; j++)
            {
                Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
                yield return new WaitForSeconds(waitPerSpawns);
            }
        }
    }
    public void ActivateSpawner()
    {
        if (!isActive)
        {
            gameObject.SetActive(true);
            isActive = true;
            StartCoroutine(SpawnSystem());
        }
    }
}

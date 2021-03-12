using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemyPreafab;
    public float enemySpawnPerSecond = 4f;

    private void Awake()
    {
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }

    private void Update()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {

        GameObject go = Instantiate<GameObject>(enemyPreafab);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float maxSpawnTime;
    private float currentSpawnTime;
    public GameObject unitPrefab;

    private void Start()
    {
        currentSpawnTime = maxSpawnTime;
    }

    private void Update()
    {
        Spawn();
    }
    private void Spawn()
    {
        currentSpawnTime += Time.deltaTime;
        if (currentSpawnTime > maxSpawnTime)
        {
            currentSpawnTime = 0;
            Instantiate(unitPrefab, transform.position, Quaternion.identity, transform);
        }
    }
    
}

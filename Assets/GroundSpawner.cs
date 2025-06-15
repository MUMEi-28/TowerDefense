using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public int maxX;
    public int maxZ;
    public GameObject ground;
    void Start()
    {
        for (int i = 0; i < maxX; i++)
        {
            for (int j = 0; j < maxZ; j++)
            {
                Instantiate(ground, new Vector3(i, 0, j), Quaternion.identity, transform);
            }
        }
        Camera.main.transform.position = new Vector3(maxX / 2, (maxX + maxZ) / 2, (maxZ / 2) / 2);
    }

    void Update()
    {
        
    }
}

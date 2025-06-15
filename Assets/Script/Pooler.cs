using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    public static Pooler sharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int ammountToPool;

    private Transform bulletParent;

    private void Awake()
    {
        sharedInstance = this;
    }
    private void Start()
    {
        bulletParent = GameObject.FindGameObjectWithTag("BulletParent").transform;

        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < ammountToPool; i++)
        {
            tmp = Instantiate(objectToPool,bulletParent);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }
   
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < ammountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}


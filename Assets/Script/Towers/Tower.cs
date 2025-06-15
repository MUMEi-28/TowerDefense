using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private SphereCollider col;
    //SHOOTING
    public Transform barrel;
    public int bulletMax;
    public float shootTime;
    private float currentShootTime;
    private Pooler pooler;
    //ENEMY
    public List<GameObject> enemies;
    public float range;

    private void Start()
    {
        pooler = GetComponent<Pooler>();

        col = GetComponent<SphereCollider>();
        col.radius = range;

        currentShootTime = shootTime;
    }
    private void Update()
    {
        LookAtEnemy();
        ShootTimer();
    }
    private void ShootTimer()
    {
        if (currentShootTime > shootTime)
        {
            currentShootTime = 0;
            Shoot();
        }
        currentShootTime += Time.deltaTime;
    }
    private void Shoot()
    {
        GameObject bullet = pooler.GetPooledObject();
        if (pooler != null && enemies.Count > 0)
        {
            bullet.transform.position = barrel.position;
            bullet.transform.rotation = barrel.rotation;
            bullet.SetActive(true);
        }
    }

    private void LookAtEnemy()
    {

        if (enemies.Count > 0)
        {
            if (enemies[0] == null)
            {
                enemies.Remove(enemies[0]);
            }
            else
            {
                GameObject target = enemies[0].gameObject;
                transform.LookAt(target.transform.position);
            }
        }

       /* if (enemies.Count <= 0)
        {
            return;
        }
        else
        {
            GameObject target = enemies[0].gameObject;
            transform.LookAt(target.transform.position);
        }*/
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemies.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemies.Remove(other.gameObject);
        }
    }
}

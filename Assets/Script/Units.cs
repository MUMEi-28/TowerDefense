using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Units : MonoBehaviour
{
    //HEALTH
    private HealthBar healthBar;
    public int maxHealth;
    private int currentHealth;

    //COINS
    public int maxCoins, minCoins;

    //MOVEMENT
    public float moveSpeed;
    private int indexOfWayPoint = 0;
    void Start()
    {
        healthBar = transform.GetChild(1).GetChild(0).GetComponent<HealthBar>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    private void Update()
    {
        MoveToWayPoint();
    }

    private void MoveToWayPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, WayPoints.Instance.waypoints[indexOfWayPoint].position, moveSpeed * Time.deltaTime);
        transform.LookAt(WayPoints.Instance.waypoints[indexOfWayPoint].position);

        if (Vector3.Distance(transform.position, WayPoints.Instance.waypoints[indexOfWayPoint].position) <= 0.1f)
        {
            if (indexOfWayPoint < WayPoints.Instance.waypoints.Length - 1)
            {
                indexOfWayPoint++;
            }
            else
            {
                Debug.Log("Unit reach final position");
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BulletPrefab")
        {
            Damage(other.gameObject.GetComponent<Bullet>().damage);
        }
    }
    private void Damage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            MainUIManager.mainUIManager.AddCoins(Random.Range(minCoins, maxCoins));
            Destroy(gameObject);
        }
    }
}
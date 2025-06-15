using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float destroyRange;
    public float moveSpeed;
    private Vector3 startingPosition;

    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        MoveForward();
        OutOfRangeDeactivate();
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
    }
    private void OutOfRangeDeactivate()
    {
        if (Vector3.Distance(transform.position, startingPosition) > destroyRange)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }
    }
}

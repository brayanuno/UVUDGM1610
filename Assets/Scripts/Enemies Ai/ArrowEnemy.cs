using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowEnemy : MonoBehaviour
{
    public Transform destination;
    private Vector3 startPosition;
    private float arrowSpeed;
    public int arrowDamage;

    private GameObject parent;

    private Rigidbody2D rb;
    private bool reachDestination;

    private void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        arrowDamage = 30;
        arrowSpeed = 25;
    }

    private void Update()
    {
        CheckingDirection();
    }

    //checking the direction of the trap 
    private void CheckingDirection()
    {
        if (!reachDestination)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination.position, arrowSpeed * Time.deltaTime); //moving
        }
        
        if (transform.position == destination.position)
        {
            transform.position = startPosition;
            reachDestination = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D col)
    { 
        if (col.transform.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>().hitpoint -= arrowDamage;
            transform.position = startPosition;
            reachDestination = false;
        }
    }
    
}

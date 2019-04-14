using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float movementSpeed = 10;
    public int trapDamage;
    private Vector2 endPosition;
    private Vector3 startPosition;
    //private Vector2 lastPosition;

    private Rigidbody2D rb;
    private bool reachDestination;

    private void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        endPosition = new Vector2(transform.position.x, -5.73f);
        reachDestination = false;
        trapDamage = 20;
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
            transform.position = Vector2.MoveTowards(transform.position, endPosition, movementSpeed * Time.deltaTime); //moving
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, startPosition, movementSpeed * Time.deltaTime); //returning
        } 

        if(transform.position == startPosition)
        {
            reachDestination = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.tag == "Ground")
        {
            reachDestination = true;
        }
        if(col.transform.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>().hitpoint -= trapDamage;
            Destroy(this.gameObject);
        }
    }
}

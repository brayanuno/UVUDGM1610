using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float speed = 4f; //movement of the enemy
    public float stoppingDistance = 5f; //the distance the enemy to stop
    public float retreatDistance = 4f; //retreat from the player

    private float timeBtwShots = 2f; //how often we shoot our projectile
    public float startTimeBtwShots;


    private Transform player;
    public GameObject projectilePlayer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        //if the enemy is far move to the target player
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        //if the enemy is close move to the target player stop moving
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        //if the enemy is too close move away from  target player 
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        //creating the particle and shooting every timeBtwShots seconds (2seconds)
        if (timeBtwShots <= 0)
        {
            Instantiate(projectilePlayer, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots; 

        } else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}

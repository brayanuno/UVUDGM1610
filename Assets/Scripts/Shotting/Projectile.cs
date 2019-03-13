using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    //public HealthBar healthBar;
    private Transform player;
    private Vector2 target;
    private int ProjectileDamage;

    private HealthBar healthBar;

    private void Awake()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        ProjectileDamage = 50;
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //targeting the player
        target = new Vector2(player.position.x, player.position.y); 
    }
    //if projectile had hit the player destroy the player(only for now)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("you were being hiited");
            healthBar.TakeDamage(ProjectileDamage);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //move the projectile to the target position(player)
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //if the projectile had reach target position destroy the particle
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    //destroying the projectile
    void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }
}

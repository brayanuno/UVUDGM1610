using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public int enemyHitPoint = 150;
    private float AttackRange = 20f;
    private int damage = 10;
    private float lastAttackTime;
    private float attackDelay = 4f; //seconds to attack again

    private bool B_FacingRight = true;

    Transform target;
    //NavMeshAgent agent;
    private HealthBar healthBar;

    [Header("MovementEnemy")]
    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 3f;
    private float enemySpeed = 2f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    private bool isEnemyClose;


    // Start is called before the first frame update
    void Start()
    {
        isEnemyClose = false;
        latestDirectionChangeTime = 0f;
        calcuateNewMovementVector();

        target = PlayerManager.instance.player.transform;
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {  
        float distance = Vector3.Distance(transform.position, target.transform.position);

        //if player is close to the radius 
        if(distance < AttackRange)
        {
            print("Player is close");
            isEnemyClose = true;
            //check if the enough attack delay passed to attack again
        if (Time.time > lastAttackTime + attackDelay)
        {
                transform.position = Vector2.MoveTowards(transform.position, target.position, -1 * enemySpeed * Time.deltaTime);
                //atacking only the player
                healthBar.TakeDamage(damage);
                //Record the time we attacked
                lastAttackTime = Time.time;
        }
        } else {      
            isEnemyClose = false;
        }

        if (!isEnemyClose)
        {
            MoveEnemy();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }

    //calculatin new movement vector
    private void calcuateNewMovementVector()
    {
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        movementDirection = new Vector2(Random.Range(-3.0f, 3.0f), 0);
        //new movement
        movementPerSecond = movementDirection * enemySpeed;
    }

    private void MoveEnemy()
    {
        //if the changeTime was reached, calculate a new movement vector
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calcuateNewMovementVector(); //calculating random movement
        }

        //move enemy: 
        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
        transform.position.y + (movementPerSecond.y * Time.deltaTime));
    }

    //flipping the character to the direction
    private void Flip()
    {
        B_FacingRight = !B_FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1; //flip
        this.transform.localScale = theScale;
    }

}

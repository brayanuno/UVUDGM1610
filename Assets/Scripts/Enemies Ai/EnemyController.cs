using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private float radarRange = 10f;
    private float AttackRange = 3f;
    private int damage = 10;
    private float enemySpeed;
    private float lastAttackTime;
    private float attackDelay = 3f; //seconds to attack again

    public Text textHitPoint;
    private bool B_FacingRight = true;

    public Image enemyhealthbar; //image health bar
    private float enemyHitPoint = 150; //enemy hit point
    private float maxEnemyHitpoint = 150;

    Animator animator;
    Transform target;
    private HealthBar healthBar; //healthbar instance
    private Transform otherTransform;

    [Header("MovementEnemy")]
    private float latestDirectionChangeTime; //the time the last direction ocurrred
    private readonly float directionChangeTime = 1f;  //direction change time(how often the movement change in enemy);
    private Vector2 movementDirection;  //random range to move the enemy
    private Vector2 movementPerSecond; //this changes every change time
    private bool isEnemyClose; //is enemy close?
    public bool move;

    //storing x position
    float lastXVal;


    // Start is called before the first frame update
    void Start()
    {
        move = true;
        enemySpeed = 6f;
        lastXVal = transform.position.x; //storing the x value
        isEnemyClose = false;
        animator = gameObject.transform.Find("EnemyGFX").GetComponent<Animator>();
        latestDirectionChangeTime = 0f;
        calcuateNewMovementVector(); //initialize with new movement ai the enemy

        target = PlayerManager.instance.player.transform; //the target is the player
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();

        float distance = Vector3.Distance(transform.position, target.transform.position);
        //if player is close to the radius 
        if (distance < radarRange) //10f is the range
        {
            isEnemyClose = true;
            FollowTarget(); //follow the target if is in range

            if(distance < AttackRange) //the enemy is close enough to attack
            {
                move = false;
                //check if the enough attack delay passed to attack again
                if (Time.time > lastAttackTime + attackDelay)
                {
                    animator.SetTrigger("Attack");
                    //atacking only the player
                    healthBar.TakeDamage(damage);
                    //Record the time we attacked
                    lastAttackTime = Time.time;
                }
            } else {
                move = true;
            }

        } else {      
            isEnemyClose = false;
            move = true;
        }

        if (!isEnemyClose)
        {
            if(move) {
                MoveEnemy();
            }
           
        }

        //checking the changing transform in every frame
        CheckingDirection();


        //changin to run and idle animations
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f)
            animator.SetFloat("MoveSpeed", 0.6f); //running
        else
            animator.SetFloat("MoveSpeed", 0f); //idle
    }
    
        
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }

    private void FollowTarget()
    {
        if(move)
        {
            //the enemy only will move in x axis 
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y)
            , enemySpeed * Time.deltaTime);
        }
    }

    //calculatin new random movement vector
    private void calcuateNewMovementVector()
    {
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        movementDirection = new Vector2(Random.Range(-2.0f, 2.0f), 0);
        //new movement iwth fixed speed
        movementPerSecond = movementDirection * enemySpeed;
    }

    //move the enemy to a random position
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

            transform.position.y + (movementPerSecond.y * Time.deltaTime)); //dont do anything with y movement
    }

    //checking and fliping in the correct way
    private void CheckingDirection()
    {
                if(transform.hasChanged)
                    //facing left
                    if (transform.position.x <lastXVal)
                    {
                        lastXVal = transform.position.x;
                        if (B_FacingRight)
                        {
                            Flip();
                        }
                        Debug.Log("Decreased!");
                        //Update lastXVal
                        lastXVal = transform.position.x;
                    }
                
                    //facing right
                    if (transform.position.x > lastXVal)
                    {
                        lastXVal = transform.position.x;

                        if (!B_FacingRight)
                        {
                            Flip();
                        }
                        Debug.Log("Increased");
                        //facing right

                        //Update lastXVal
                        lastXVal = transform.position.x;
                    }

            transform.hasChanged = false;
        
    }

    //flipping the character to the direction
    private void Flip()
    {
        B_FacingRight = !B_FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1; //flip
        this.transform.localScale = theScale;
    }
    //receive Damage of enemy
    public void ReceivingDamage(int Damage)
    {
        enemyHitPoint -= damage;
    }

    //updating health and healthbar
    private void UpdateHealth()
    {
        float ratio = enemyHitPoint / maxEnemyHitpoint;
        enemyhealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1); //scaling the image

        //if enemy has below 0 hp
        if (enemyHitPoint <= 0)
        {
            enemyHitPoint = 0;
            Die();
            //enemy had died
        }

        //if enemy reaches the max hit point
        if (enemyHitPoint> maxEnemyHitpoint)
        {
            enemyHitPoint = maxEnemyHitpoint;
        }
    }
    private void Die()
    {
        Destroy(this.gameObject);
    }

    

}

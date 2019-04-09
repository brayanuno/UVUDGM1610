using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject BloodSplash;
    private float radarRange = 10f;
    private float AttackRange = 2f;
    public int damage = 10;
    public float enemySpeed;
    private float lastAttackTime;
    private float attackDelay = 3f; //seconds to attack again
    public float stopRange = 1.8f;
    private int coinValue = 100;
    private bool B_FacingRight = true;

    public Image enemyhealthbar; //image health bar
    public int enemyHitPoint; //enemy hit point
    private int maxEnemyHitpoint;
    
    Animator animator;
    Transform target;
    private HealthBar healthBar; //healthbar instance
    private Transform otherTransform;

    [Header("MovementEnemy")]
    private float latestDirectionChangeTime; //the time the last direction ocurrred
    private float directionChangeTime ;  //direction change time(how often the movement change in enemy);
    private Vector2 movementDirection;  //random range to move the enemy
    private Vector2 movementPerSecond; //this changes every change time
    private bool isEnemyClose; //is enemy close?

    private Vector3 lastPos;
    private bool enemyMov;

    public bool receivingDamage;
    public bool move; //the enemy can move
    
    //storing x position
    float lastXVal;


    // Start is called before the first frame update
    void Start()
    {
        move = true;
        maxEnemyHitpoint = enemyHitPoint;
        directionChangeTime = 3f;
        latestDirectionChangeTime = 0f;
        isEnemyClose = false;
        lastPos = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        target = PlayerManager.instance.player.transform; //the target is the player
        lastXVal = transform.position.x; //storing the x value
        animator = gameObject.transform.Find("EnemyGFX").GetComponent<Animator>();

        if (!isEnemyClose)
        {
            if(move) 
                MoveEnemy();
        }

        UpdateHealth();
        float distance = Vector3.Distance(transform.position, target.transform.position);

        //if player is close to the radius 
        if (distance < radarRange) //is player is in the radar of the enemy
        {
            isEnemyClose = true;
            FollowTarget(); //follow the target if is in range

            if (distance < AttackRange && isEnemyClose) //the enemy is close enough to attack
            {
                //check if the enough attack delay passed to attack again
                if (Time.time > lastAttackTime + attackDelay)
                {
                    animator.SetTrigger("Attack");
                    //atacking only the player
                    healthBar.TakeDamage(damage);
                    //animating the enemy character(player)
                    PlayerManager.instance.player.GetComponent<PlayerBehaviour>().receivingDamage = true;
                    //Record the time we attacked
                    lastAttackTime = Time.time;

                }
                else { } //PlayerManager.instance.player.GetComponent<PlayerBehaviour>().receivingDamage = false;} }

                if (distance < stopRange) //stop the movement
                {
                    move = false;
                }
            }
            else
            {
                move = true; //if is not close just move
            }

        } else
        {
            isEnemyClose = false;
            move = true; //move enemy is not close
        }

        EnemyMoved();
        //BeingHitted();
        CheckingDirection();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }

    private void FollowTarget()
    {
        //always keep distance from player and enemy
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
        movementDirection = new Vector2(Random.Range(-2f, 2f), 0);
        //new movement iwth fixed speed
        movementPerSecond = movementDirection * enemySpeed;
   
    }

    //move the enemy to a random position
    private void MoveEnemy()
    {
            //if the changeTime was reached, calculate a new movement vector
            if (Time.time - latestDirectionChangeTime > directionChangeTime)
            {
                calcuateNewMovementVector(); //calculating random movement
      
                latestDirectionChangeTime = Time.time;
            }
            //move enemy: 
            transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
            transform.position.y + (movementPerSecond.y * Time.deltaTime)); //dont do anything with y movement
    }

    //checking and fliping in the correct way
    private void CheckingDirection()
    {
        if(transform.hasChanged) { 
        //facing left
            if (transform.position.x <lastXVal)
            {
            lastXVal = transform.position.x;
                if (B_FacingRight)
                {
                   Flip();

                }
                     
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

                //facing right

                //Update lastXVal
                lastXVal = transform.position.x;
            }
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
        enemyHitPoint -= Damage;
        animator.SetTrigger("Hit");
        BeingHitted();
        print("receiving damage");
    }

    private void Die()
    {
        GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>().UpdateScore(coinValue);

        Destroy(this.gameObject);
        
    }

    public void BeingHitted()
    {
        GameObject prefab = Instantiate(BloodSplash,transform);
        Destroy(prefab,1f);
    }
    //updating health and healthbar
    private void UpdateHealth()
    {
        float ratio = (float)enemyHitPoint / maxEnemyHitpoint;
        enemyhealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1); //scaling the image

        //if enemy has below 0 hp
        if (enemyHitPoint <= 0)
        {
            enemyHitPoint = 0;
            Die(); //enemy had died
        }

        //if enemy reaches the max hit point
        if (enemyHitPoint > maxEnemyHitpoint)
        {
            enemyHitPoint = maxEnemyHitpoint;
        }
    }
    private void EnemyMoved()
    {
        Vector3 displacement = transform.position - lastPos;
        lastPos = transform.position;
        if (displacement.magnitude > 0.001)  // return true if char moved 1mm
        {
            animator.SetFloat("MoveSpeed", 1f); //running
            //print("running");
        }
        else
        {
            animator.SetFloat("MoveSpeed", 0f); //idle
           // print("idle");
        }
    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Animator animator;
    private EnemyController enemyController; //store the instance of enemy controller
    private PlayerAnimal playerAnimal;
    private float radarPlayer = 15f; //the radar range 
    private float attackRange = 4f; //the attack range will not work collider are better
    public Transform[] transArray;

    public int playerDamage = 10;
    private float lastAttackTime;  //Record the time we attacked
    public float attackDelay;  //seconds to attack again 

    public bool receivingDamage; //the enemy is beign hiite run animation
    public bool isEnemyClose;  //the enemy is close?

    private void Awake()
    {

    }


    private void Start()
    {
        //isNoRange = true;
        attackDelay = 0.367f; //the exact frame of the animation attack; //future will change
        animator = gameObject.transform.Find("PlayerModel").GetComponent<Animator>();
        playerAnimal = PlayerManager.instance.player.GetComponent<PlayerAnimal>();
    }       

    private void Update()
    {
       
        //storing all the enemies in the scene
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        transArray = new Transform[Enemies.Length];
        for (int i = 0; i < Enemies.Length; i++ )
        {
            transArray[i] = Enemies[i].transform;
        }
        AttackingEnemies();
        BeingHitted();
    }

    //getting the closest enemy and best target
    public Transform GetClosestEnemy(Transform[] enemies)
    {
        float closestDistanceSqr = Mathf.Infinity;
        Transform bestTarget = null; 
        Vector3 currentPosition = transform.position;

        foreach (Transform potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;

            float dSqrToTarget = directionToTarget.sqrMagnitude;

            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;
    }

    //Attacking Enemies
    public void AttackingEnemies()
    {
        //get closest enemy distance with the best target and close enemy
        float distance = Vector3.Distance(transform.position, GetClosestEnemy(transArray).transform.position);
        //name of the best target enemy
        string bestTargetName = GetClosestEnemy(transArray).transform.name;

        //if the player is close to the radar range
        if (distance < radarPlayer)
        {
            //calling the PanelControl to active the alert of an enemy 
            PanelControls.instance.ActivatePanel(PanelControls.instance.AlertPanel,bestTargetName);

            //if the player is close to the attack range
            if (isEnemyClose == true)
            {
                //check if the enough attack delay passed to attack again and the animation is running
                if (Time.time > lastAttackTime + attackDelay && isPlaying(animator, "Attack") && isEnemyClose )
                {
                  
                    //reducing damage to the enemy
                    enemyController = GetClosestEnemy(transArray).GetComponent<EnemyController>();
                    enemyController.ReceivingDamage(playerDamage);
                    enemyController.receivingDamage = true;


                  //Record the time we attacked
                  lastAttackTime = Time.time;
                }
            }

        } else { 
            PanelControls.instance.DesactivatePanel(PanelControls.instance.AlertPanel);
        }
    }

    public bool isPlaying(Animator anim, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
                anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radarPlayer);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    //if player is in collision
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(gameObject.GetComponent<Collider2D>().enabled == true)
        {
            // == enemy
            if (collision.gameObject.transform.name == GetClosestEnemy(transArray).transform.name)
            {
                isEnemyClose = true;
            }
            else
            {
                isEnemyClose = false;
            }
        } 
    }

    private void BeingHitted()
    {
        if (receivingDamage)
        {
 
            animator.SetTrigger("Hit");
            receivingDamage = false;
        } 
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Animator animator;
    private EnemyController enemyController; //store the instance of enemy controller
    private float radarPlayer = 15f; //the radar range
    private float attackRange = 4f; //the attack range
    Transform[] transArray;

    public int playerDamage = 10;
    private float lastAttackTime;  //Record the time we attacked
    public float attackDelay;  //seconds to attack again 
    
    private bool isEnemyClose;


    private void Start()
    {
        attackDelay = 0.367f; //the exact frame of the animation attack;
        animator = gameObject.transform.Find("PlayerModel").GetComponent<Animator>();
        
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
            //calling the PanelControl to active the alert of an enemy for 5 seconds
            PanelControls.instance.ActivatePanel(PanelControls.instance.AlertPanel,bestTargetName);

            //if the player is close to the attack range
            if (isEnemyClose)
            {
                print("is close is true");
                //check if the enough attack delay passed to attack again and the animation is running
                if (Time.time > lastAttackTime + attackDelay && isPlaying(animator, "Attack"))
                {
                    print("animation is playing");
                    //reducing damage to the enemy
                    enemyController = GetClosestEnemy(transArray).GetComponent<EnemyController>();
                    enemyController.ReceivingDamage(playerDamage);

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


    public void Attack1()
    {
        
    }

    public void Attack2()
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //gameObject.GetComponent<PlayerAnimal>().move = false;
            print("you can move too close");
            isEnemyClose = true;
            gameObject.GetComponent<PlayerAnimal>().jump = true;
        } else
        {
            //gameObject.GetComponent<PlayerAnimal>().move = true;
            isEnemyClose = false;
            
        }
    }
 

}


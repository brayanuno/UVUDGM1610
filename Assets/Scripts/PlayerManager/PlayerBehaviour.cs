using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;
    private Animator animator;
    private EnemyController enemyController; //store the instance of enemy controller
    private float radarPlayer; //the radar range  15
    private Transform[] transArray; //stores all enemies data 

    private float lastAttackTime;  //Record the time we attacked
    public float attackDelay;  //seconds to attack again 

    public int playerDamage;
    public bool receivingDamage; //the enemy is beign hiite run animation
    public bool isEnemyClose;  //the enemy is close?

    private float attack2Delay = 2.5f;

    //playerShooting
    public Transform firePoint;
    public bool rangeDelay;


    void Start()
    {
     
        playerInfo = PlayerInfo.instance;
        attackDelay = 0.367f; //the exact frame of the animation attack; //future will change
        playerDamage = playerInfo.playerDamage;
        rangeDelay = true;

    }

    private void FixedUpdate()
    {
        //checking if restart stats is allow
        if (!playerInfo.restartStats)
        {
            return;
        }
        else
        {
            radarPlayer = playerInfo.radarPlayer;
            playerDamage = playerInfo.playerDamage;
        }
    }

    private void Update()
    {
        StoringEnemies();
        AttackingEnemies();
        BeingHitted();
        animator = gameObject.transform.Find("PlayerModel").GetComponent<Animator>();
    }

    //getting the closest enemy and best target
    public Transform GetClosestEnemy()
    {

        float closestDistanceSqr = Mathf.Infinity;
        Transform bestTarget = null; 
        Vector3 currentPosition = transform.position;

        foreach (Transform potentialTarget in transArray) //enemies
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

    public void StoringEnemies()
    {
        //storing all the enemies in the scene
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy"); //all the enemies in the scene
        transArray = new Transform[Enemies.Length];

        for (int i = 0; i < Enemies.Length; i++)
        {
            transArray[i] = Enemies[i].transform;
        }
    }

    //Attacking Enemies
    public void AttackingEnemies()
    {
        //get closest enemy distance with the best target and close enemy
        float distance = Vector3.Distance(transform.position, GetClosestEnemy().transform.position);
        //name of the best target enemy
        string bestTargetName = GetClosestEnemy().transform.name;

        //if the player is close to the radar range
        if (distance < radarPlayer)
        {
            //calling the PanelControl to active the alert of an enemy 
            PanelControls.instance.ActivatePanel(PanelControls.instance.AlertPanel,bestTargetName + " is close");

            //check if the enough attack delay passed to attack again and the animation is running
                if (Time.time > lastAttackTime + attackDelay && isPlaying(animator, "Attack") && isEnemyClose)
                {
                    lastAttackTime = Time.time;
                    //reducing damage to the enemy
                    enemyController = GetClosestEnemy().GetComponent<EnemyController>();
                    enemyController.ReceivingDamage(playerDamage);
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

    private void BeingHitted()
    {
        if (receivingDamage)
        {
            GameObject someCoolPrefab = Instantiate(Resources.Load("Prefabs/BloodSplash") as GameObject, firePoint);
            animator.SetTrigger("Hit");
            Destroy(someCoolPrefab,1f);
            receivingDamage = false;
        } 
    }

    public GameObject ClosestEnemyObject()
    {
        return GetClosestEnemy().gameObject;
    }

    //Shooting
    public IEnumerator Shooting()
    {
        GameObject projectile = Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, firePoint.position, Quaternion.identity);
        rangeDelay = false;
        yield return new WaitForSeconds(2.5f);
        rangeDelay = true;
                
    }

    public void PowerEffect(GameObject particle)
    {
        GameObject projectile = Instantiate(particle,firePoint.position, Quaternion.identity);
        Destroy(projectile, 2);
    }
    
}


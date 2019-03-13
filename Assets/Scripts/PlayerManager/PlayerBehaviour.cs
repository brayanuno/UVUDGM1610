using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Animator animator;

    private float rangePlayer = 10f;
    Transform[] transArray;

    public int damage = 10;
    private float lastAttackTime;  //Record the time we attacked
    public float attackDelay = 1f;  //seconds to attack again 

    private void Start()
    {
        
       //animator = gameObject.transform.Find("Animator").GetComponent<Animator>();
    }       

    private void Update()
    {
        //storing the enemies in the scene
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

    public void AttackingEnemies()
    {
 
        float distance = Vector3.Distance(transform.position, GetClosestEnemy(transArray).transform.position);
        //print(distance);
        if (distance < rangePlayer)
        {
            print("working");
            //check if the engough attack delay passed to attack again
            if (Time.time > lastAttackTime + attackDelay)
            {
                
 
                //Record the time we attacked
                lastAttackTime = Time.time;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangePlayer);
    }

    public void Attack1()
    {
        
    }

    public void Attack2()
    {

    }
}

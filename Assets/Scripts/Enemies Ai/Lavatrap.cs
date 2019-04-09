using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lavatrap : MonoBehaviour
{
    private float savedTime;
    private float delayTime;
    private int lavaDamage;

    private void Start()
    {
        savedTime = 0f;
        delayTime = 2f;
        lavaDamage = 40;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            print("the player touch the lava");
            //everyTwoSeconds if is the player is in the  the lava cause damage
            if ((Time.time - savedTime) > delayTime)
            {
                savedTime = Time.time;
                GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>().hitpoint -= lavaDamage;
            }
        }

    }
}

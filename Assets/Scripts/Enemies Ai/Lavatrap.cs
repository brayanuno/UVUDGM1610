using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lavatrap : MonoBehaviour
{
    private float SavedTime = 0;
    private float DelayTime = 2;
    private int lavaDmaage = 10;


    void OnTriggerStay2D(Collider2D other)
    {
        //everyTwoSeconds if is indexer the lava cause damage
        if ((Time.time - SavedTime) > DelayTime)
        {
            SavedTime = Time.time;
            GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>().hitpoint -= lavaDmaage;
            print("is in lava");
        }

    }
}

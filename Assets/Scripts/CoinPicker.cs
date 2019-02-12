using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPicker : MonoBehaviour
{
    public GameObject PC;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "PC")
        {
            print("COLLECT COIN");
        }
        else
        {

        }
    }
}

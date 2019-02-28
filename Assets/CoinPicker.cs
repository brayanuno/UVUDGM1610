using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPicker : Functions
{
    public HealthBar healthbar;
    public RandomSpawn randomSpawn;
    public bool objectDestroyed = true; //instantiate with true 

    private void OnTriggerEnter2D(Collider2D other)
    {
        //on trigger with coin objects
        if(other.gameObject.tag == "coin")
        {
            CollectCoin();
            
            Destroy(randomSpawn.instanstiateCoin);
            healthbar.hitpoint += 30;
        }
              
    }
}

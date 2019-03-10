using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : CoinPicker
{
    public GameObject coin;
    public float spawnRate = 3f; //time to respawn the next 
    public float nextSpawn = 0f;
    private float rand;
    public Vector2 whereToSpawn;
    public GameObject instanstiateCoin;

    void Update()
    {

        if(Time.time > nextSpawn && objectDestroyed == true)
        {
            //setting random numbers from 1 to 6
            rand = Random.Range(-6.4f, 6.4f);
            whereToSpawn = new Vector2(rand, -1.98f);
            instanstiateCoin = Instantiate(coin, whereToSpawn, Quaternion.identity); //storing instantiate prefab
            nextSpawn = Time.time + spawnRate;

        }

        //if gameobject is null set to true 
        if (instanstiateCoin == null) {
            objectDestroyed = true;
        }
        else {
            objectDestroyed = false;
        }
    }
}

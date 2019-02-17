using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : CoinPicker
{
    public GameObject coin;
    public float spawnRate = 3f; //time to respawn the next 
    public float nextSpawn = 0f;
    private float rand;
    private Vector2 whereToSpawn;
    public GameObject instanstiateCoin;

    void Update()
    {

        if(Time.time > nextSpawn && objectDestroyed == true)
        {
            //setting random numbers from 1 to 6
            rand = Random.Range(-8.4f, 8.4f);
            whereToSpawn = new Vector2(rand, transform.position.y);
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

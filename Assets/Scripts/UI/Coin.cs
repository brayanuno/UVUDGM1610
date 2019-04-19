using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private int scoreCoin;
    private ScoreManager scoreManager;
    
    private void Start()
    {
        scoreCoin = 40;
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.tag == "player")
        {
            scoreManager.UpdateScore(scoreCoin);
            Destroy(col.gameObject);
        }
        
    }
}

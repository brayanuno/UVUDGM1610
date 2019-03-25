using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private int score;
    private ScoreManager scoreManager;
    
    
    private void Start()
    {
        score = 10;
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.tag == "Player")
        {
            scoreManager.UpdateScore(score);
            Destroy(gameObject);
        }
        
    }
}

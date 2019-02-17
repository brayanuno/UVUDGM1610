using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Functions : PlayerAnimal
{
    public int coinScore;
    public Text scoreText;

     void Start()
    {
        coinScore = 0;
        scoreText.text = "Score: " + coinScore.ToString();

    }

    public void CollectCoin()
    {   
        coinScore += 20;
        scoreText.text = "Score: " + coinScore.ToString();

    }
   

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Functions : MonoBehaviour
{
    public int coinScore;
    public Text scoreText;

     void Start()
    {
        print(Sum(36, 24));
        print(Multi(36, 24));
        coinScore = 0;
        scoreText.text = "Score: " + coinScore.ToString();

    }

    public void CollectCoin()
    {   
        coinScore += 20;
        scoreText.text = "Score: " + coinScore.ToString();

    }
   
    int Sum(int a,int b)
    {
        return a + b;
    }

    int Multi(int a, int b)
    {
        return a * b;
    }        
}

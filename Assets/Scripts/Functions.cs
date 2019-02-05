using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Functions : MonoBehaviour
{
    public Functions coin;
    private int coinScore;
    public Text scoreText;

     void Start()
    {
        coinScore = 0;
        scoreText.text = "Score: " + coinScore.ToString();

    }


    void OnMouseOver()
    {
        collectCoin();
    }

    void collectCoin()
    {   
        coinScore += 20;
        scoreText.text = "Score: " + coinScore.ToString();
        print(coinScore);
    }


}

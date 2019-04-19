using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score; //score coin value
    [SerializeField]private Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = 100;
    }

    private void Update()
    {
        scoreText.text = score.ToString() + " score";
    }

    //method to update the score
    public void UpdateScore(int score)
    {
        this.score += score;
    }
    public void BuyScore(int score)
    {
        this.score -= score;
    }
    
}

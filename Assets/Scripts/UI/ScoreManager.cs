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
        score = 0;
    }

    void update()
    {
        scoreText.text = score.ToString();
    }

    //method to update the score
    public void UpdateScore(int score)
    {
        this.score += score;
    }
}

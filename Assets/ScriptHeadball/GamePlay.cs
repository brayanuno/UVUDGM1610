using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay: MonoBehaviour
{
    //gameobjects
    public GameObject player;
    private Vector3 originalPosPlayer;
    public GameObject secondaryPlayer;
    private Vector3 originalsecondaryPlayer;
    public GameObject ball;
    private Vector3 originalBall;

    //variable
    public int scorePlayer;
    public int scoreSecondaryPlayer;
    public Text scorePlayerText;
    public Text scoreSecondaryPlayerText;
    //timer
    private float targetTime = 60.0f;
    public Text time;
    private bool onetime;

    public GameObject victory;
    public Text victoryText;
    public GameObject draw;
    public Text drawText;

    

    // Start is called before the first frame update
    void Start()
    {
        scorePlayer = 0;
        scoreSecondaryPlayer = 0;
        onetime = false;
        PositionInitGame();

        victory.SetActive(false);
        draw.SetActive(false);

       
    }
    //updating Score
    void Update()
    {
        //updating the score every frame
        scorePlayerText.text = scorePlayer.ToString();
        scoreSecondaryPlayerText.text = scoreSecondaryPlayer.ToString();

        //setting limit of time per match
        targetTime -= Time.deltaTime;
        time.text = (targetTime).ToString("0");

        


        //game is over
        if (targetTime < 1)
        {
            Invoke("ChoosingWinner", 1);
            //RestartGame();
            Invoke("EndfGame", 2);
        }

    }
    //saving position initial of the playerPostion
    void PositionInitGame()
    {   
        originalBall = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z);
        originalPosPlayer = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        originalsecondaryPlayer = new Vector3(secondaryPlayer.transform.position.x, secondaryPlayer.transform.position.y, secondaryPlayer.transform.position.z);
    }
   
    private void RestartGame()
    {
       

    }
    //when anyone score a goal
    public void ScoreGoal()
    {
        ball.transform.position = originalBall;
        player.transform.position = originalPosPlayer;
        secondaryPlayer.transform.position = originalsecondaryPlayer;
    }

    //end game
    private void EndfGame()
    {
        ball.transform.position = originalBall;
        player.transform.position = originalPosPlayer;
        secondaryPlayer.transform.position = originalsecondaryPlayer;
    }
  
    void ChoosingWinner()
    {
        if(scorePlayer > scoreSecondaryPlayer)
        {
            victory.SetActive(true);
            victoryText.text = "PLAYER WON";
            

        }
        else if (scorePlayer < scoreSecondaryPlayer)
        {
            victory.SetActive(true);
            victoryText.text = "SECOND PLAYER WON";
        }

        else {
            draw.SetActive(true);
            drawText.text = "DRAW NOBODY WINS THIS TIME";
        }
    }
}

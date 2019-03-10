using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    float timeLeft = 30.0f;

    private void Start()
    {
        timer.text = "0";
    }
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timer.text = "TimeLeft: " + Mathf.Round(timeLeft);
        if (timeLeft < 0)
        {
            timeLeft = 0;
            //destroying the player when time is Over
           GameObject player = GameObject.FindWithTag("Player");
           Destroy(player);
        }
    }
}

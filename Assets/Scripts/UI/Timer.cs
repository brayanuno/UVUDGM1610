using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject GameOver;
    
    public Text timer;
    float timeLeft = 120.0f;

    private void Start()
    {
        timer.text = "0";
        GameOver.SetActive(false);
    }
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timer.text = "TimeLeft: " + Mathf.Round(timeLeft);
        if (timeLeft < 0)
        {
            timeLeft = 0;
            GameOver.SetActive(true);
            GameObject player = GameObject.FindWithTag("Player");
            Destroy(player);
        }
    }

    public void LobbyReturn(int index)
    {
        SceneManager.LoadScene(0);
    }
}

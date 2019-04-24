using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    [SerializeField] private GameObject Victory;
    [SerializeField] private GameObject Losing;
    [SerializeField] private Text Enemiestext;

    // Start is called before the first frame update
    void Start()
    {
        Victory.SetActive(false);
        Losing.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Win();
        EnemiesCount();
    }

    private int EnemiesLeft()
    {
        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        return enemyCount;
    }

    private void Win()
    {
        if(EnemiesLeft() == 0)
        {
            Victory.SetActive(true);
            StartCoroutine(WaitTime(2)); 
        }
    }

    public void Lose()
    {
        Losing.SetActive(true);
        StartCoroutine(WaitTime(2));
    }

    private void EnemiesCount()
    {
        Enemiestext.text = EnemiesLeft().ToString();
    }
     
    IEnumerator WaitTime(int time)
    {  
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(0);
    }

}


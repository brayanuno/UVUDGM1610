using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    public GameObject[] powerUps;
    //move faster  playerSpeed 
    public PlayerAnimal playerAnimal;
    public HealthBar healthBar;

    private float powerSeconds = 5f;

    private void Start()
    {
 
    }
    void Update()
    {
      
    }

    public IEnumerator UsePower(int index)
    {
        switch(index)
        {
            case 1:
                playerAnimal.playerSpeed = 10;
                powerUps[0].GetComponent<Image>().color = Color.white;

                yield return new WaitForSeconds(powerSeconds);
                playerAnimal.playerSpeed = 4;
                Destroy(powerUps[0]);
                break;

            case 2:
                playerAnimal.jumpHeight = 10;
                powerUps[1].GetComponent<Image>().color = Color.white;

                yield return new WaitForSeconds(powerSeconds);
                playerAnimal.jumpHeight = 5;
                Destroy(powerUps[1]);
                break;

            case 3:
                healthBar.hitpoint += 40;
                powerUps[2].GetComponent<Image>().color = Color.white;
                yield return new WaitForSeconds(powerSeconds);
                Destroy(powerUps[2]);
                break;
        }
    }
   

    public int PowerUsed()
    {
        return 1;
    }
}

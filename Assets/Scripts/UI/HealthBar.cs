using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private PlayerInfo playerInfo; 
    public Image healthBar;
    public Text ratioText;
    public GameObject HealthDisplayCanvas;
    private Text username;
    public int hitpoint;
    public int maxHitpoint;

    private void Start()
    {
        playerInfo = PlayerInfo.instance;
        username = GameObject.FindGameObjectWithTag("Username").GetComponent<Text>();
        
    }
    private void FixedUpdate()
    {
        UpdateHealth();
        //checking if restart stats is allow
        if (!playerInfo.restartStats)
        {
            return;
        }
        else
        {
            username.text = playerInfo.username;
            hitpoint = playerInfo.hitPoint;
            maxHitpoint = playerInfo.hitPoint;
        }
    }

    void Update()
    { 
        HealthDisplayCanvas = PlayerManager.instance.player.transform.Find("HealthDisplayCanvas").gameObject;
        //hitpoint -= Time.deltaTime * decreasePerMinute / 5f;
        UpdateHealth();

    }

    //updating the health everyframe
     private void UpdateHealth()
     {
         float ratio = (float)hitpoint / maxHitpoint;
         healthBar.rectTransform.localScale = new Vector3(ratio, 1, 1); //scaling the health bar
         ratioText.text = (ratio * 100).ToString("0") + "%";

         //if player has below 0 hp
         if (hitpoint <= 0 && !playerInfo.restartStats)
         {
            hitpoint = 0;
            PlayerManager.instance.player.GetComponent<PlayerAnimal>().Die(); //calling the die function
         }
         //if player reaches the max hit point
         if (hitpoint > maxHitpoint)
         {
            hitpoint = maxHitpoint;
         }
    }

     //taking damage
     public void TakeDamage(int damage)
     {
         hitpoint = hitpoint - damage;
         StartCoroutine(WaitAndPrint(1.0f , damage));
     }

     //displaying the damage 
     public IEnumerator WaitAndPrint(float waitTime , int text)
     {
        HealthDisplayCanvas.SetActive(true);
        HealthDisplayCanvas.transform.Find("Text").GetComponent<Text>().text = "- " + text.ToString(); 
        yield return new WaitForSeconds(waitTime);
        HealthDisplayCanvas.SetActive(false);
     }
}
    

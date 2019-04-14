using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private PlayerInfo playerInfo; 
    public Image healthBar;
    public GameObject HealthDisplayCanvas;
    private Text username;
    public int hitpoint;
    public int maxHitpoint;

    [SerializeField]private Text hitPoint;

    private void Start()
    {
        playerInfo = PlayerInfo.instance;
        username = GameObject.FindGameObjectWithTag("Username").GetComponent<Text>();
        
    }
    private void FixedUpdate()
    {
        UpdateHealth();
        username.text = playerInfo.username;
        //checking if restart stats is allow
        if (!playerInfo.restartStats)
        {
            return;
        }
        else
        {
            hitpoint = playerInfo.hitPoint;
            maxHitpoint = playerInfo.hitPoint;
        }

    }

    void Update()
    { 
        HealthDisplayCanvas = PlayerManager.instance.player.transform.Find("HealthDisplayCanvas").gameObject;
        hitPoint.text = hitpoint + "/" + maxHitpoint;
    }

    //updating the health everyframe
     private void UpdateHealth()
     {
         float ratio = (float)hitpoint / maxHitpoint;
         healthBar.rectTransform.localScale = new Vector3(ratio, 1, 1); //scaling the health bar


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

     //public void increaseMaxHitpoint(int hitPoint,bool active)
     //{
        //if(active)
        ///{
        
        ////    maxHitpoint += hitPoint;
        /////}
        //else
        ///{
            
        ////    maxHitpoint -= hitPoint;   
       //// }
    
     ///}
}
    

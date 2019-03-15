using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerAnimal player;
    public Image healthBar;
    public Text ratioText;
    public GameObject HealthDisplayCanvas;


    public float hitpoint;
    private float maxHitpoint = 250;

    private void Awake()
    {
        hitpoint = 250f; //setting the playerHealth
    }
    void Update()
    {
        //hitpoint -= Time.deltaTime * decreasePerMinute / 5f;
        UpdateHealth();
    }
    //updating the health everyframe
     private void UpdateHealth()
     {
         float ratio = hitpoint / maxHitpoint;
         healthBar.rectTransform.localScale = new Vector3(ratio, 1, 1); //scaling the 
         ratioText.text = (ratio * 100).ToString("0") + "%";
         //if player has below 0 hp
         if (hitpoint <= 0)
         {
            hitpoint = 0;
            player.Die();
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
         hitpoint -= damage;
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
    

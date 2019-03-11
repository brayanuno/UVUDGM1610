using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerAnimal player;
    public Image healthBar;
    public Text ratioText;

    public float hitpoint = 150;
    private float maxHitpoint = 150;
    private float decreasePerMinute = 50f;

    void Update()
    {
        hitpoint -= Time.deltaTime * decreasePerMinute / 5f;
        UpdateHealth();
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

        //if (hitpoint > 0)
        //{ 
            //if (hitpoint > 0 && hitpoint > 10)
           // {
                //print("terrible HP");
            //}
            //else if (hitpoint > 0 && hitpoint < 20)
            //{
               // print("bad HP");
            //}
            //else if (hitpoint > 0 && hitpoint < 30)
            //{
            //    print("low HP");
            //}
            //else if (hitpoint > 0 && hitpoint < 40)
            //{
             //   print("average HP");
            //}
            //else if (hitpoint > 0 && hitpoint < 50)
            //{
               // print("medium HP");
            //}
            //else if (hitpoint > 0 && hitpoint < 60)
           // {
               // print("high HP");
            //}
       // } 
    }

        private void UpdateHealth()
        {
            float ratio = hitpoint / maxHitpoint;
            healthBar.rectTransform.localScale = new Vector3(ratio, 1, 1); //scaling the 
            ratioText.text = (ratio * 100).ToString("0") + "%";
        }
    }
    

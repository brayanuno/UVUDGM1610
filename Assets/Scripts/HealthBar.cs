using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : PlayerAnimal
{
    public Image healthBar;
    public Text ratioText;

    public float hitpoint = 150;
    private float maxHitpoint = 150;
    private float decreasePerMinute = 60f;

    void Update()
    {
        hitpoint -= Time.deltaTime * decreasePerMinute / 5f;
        UpdateHealth();
        //if player has below 0 hp
        if (hitpoint < 0)
        {
            hitpoint = 0;
            Die();
        }
        //if player reaches the max hit point
        if (hitpoint > maxHitpoint)
        {
            hitpoint = maxHitpoint;
        }
    }
    private void UpdateHealth()
    {
        float ratio = hitpoint / maxHitpoint;
        healthBar.rectTransform.localScale = new Vector3(ratio, 1, 1); //scaling the 
        ratioText.text = (ratio * 100).ToString("0") + "%";
    }
}

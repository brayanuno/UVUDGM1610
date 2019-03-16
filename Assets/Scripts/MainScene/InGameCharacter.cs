using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class storage all the information of the player 
/// </summary>
/// 
public class InGameCharacter
{
    private string userName;
    private int hitPoint;
    private float radarPlayer;
    private float playerDamage;
    private float speedPlayer;
    private float jumpHeight;
    

    //parameters to send to another 
    public InGameCharacter(string userName,int hitPoint, float radarPlayer, float playerDamage, float speedPlayer, float jumpHeight) {

        this.userName = userName;
        this.hitPoint = hitPoint;
        this.radarPlayer = radarPlayer;
        this.playerDamage = playerDamage;
        this.speedPlayer = speedPlayer;
        this.jumpHeight = jumpHeight;
    }
    public void CreateClass()
    {

    }
}

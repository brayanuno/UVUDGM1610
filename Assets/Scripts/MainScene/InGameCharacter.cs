using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class storage all the information 
/// </summary>
/// 
public class InGameCharacter
{ 
    public int id;
    public string userName;
    public int hitPoint;
    public float radarPlayer;
    public int playerDamage;
    public float speedPlayer;
    public float jumpHeight;
   

    //parameters to send to another 
    public InGameCharacter(int id,string userName,int hitPoint, float radarPlayer, int playerDamage, float speedPlayer, float jumpHeight) {

        this.id = id;
        this.userName = userName;
        this.hitPoint = hitPoint;
        this.radarPlayer = radarPlayer;
        this.playerDamage = playerDamage;
        this.speedPlayer = speedPlayer;
        this.jumpHeight = jumpHeight;
    }
    
}

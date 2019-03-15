using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        //the enemy is inside the collider
        if (collision.gameObject.tag == "Player")
        {
            print("touch the back of the enemy");
        }
    }
}

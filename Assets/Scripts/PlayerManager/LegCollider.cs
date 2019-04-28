using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegCollider : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            PlayerManager.instance.player.GetComponent<PlayerAnimal>().jumpAmount = PlayerManager.instance.player.GetComponent<PlayerAnimal>().maxjumps;
            PlayerManager.instance.player.GetComponent<PlayerAnimal>().grounded = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderWeapon : MonoBehaviour
{
    //if player is in collision
    private void OnTriggerStay2D(Collider2D other)
    {
            // == enemy
            if (other.gameObject.transform.name == PlayerManager.instance.player.GetComponent<PlayerBehaviour>().GetClosestEnemy().transform.name)
            {
                PlayerManager.instance.player.GetComponent<PlayerBehaviour>().isEnemyClose = true;
            }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerManager.instance.player.GetComponent<PlayerBehaviour>().isEnemyClose = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Enemy")
        {
            Destroy(col.gameObject);
            return;
        }
        print("lose");
        GameObject.FindGameObjectWithTag("GamePlayManager").GetComponent<GameState>().Lose();
    }
   

}

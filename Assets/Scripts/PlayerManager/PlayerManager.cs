using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //singleton to call to other scripts
    public static PlayerManager instance;
    public GameObject player;
    void Awake()
    {

        instance = this;
    }

    private void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
   
    
}

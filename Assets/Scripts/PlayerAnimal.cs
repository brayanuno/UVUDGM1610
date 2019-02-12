using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimal : MonoBehaviour
{
    public int playerSpeed = 4;
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(playerSpeed * Time.deltaTime, 0f, 0f);  //makes player run right

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-playerSpeed * Time.deltaTime, 0f, 0f);  //makes player run left

        }
    }
}

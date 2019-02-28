using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimal : MonoBehaviour
{
    public GameObject collect;
    public int playerSpeed = 4;
    public int jumpHeight = 5;

    void Start()
    {

    }

    void Update()
    {
        //losing healht
        //health -= Time.deltaTime * decreasePerMinute / 60f;
        //print(health);

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(playerSpeed * Time.deltaTime, 0f, 0f);  //makes player run right

        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-playerSpeed * Time.deltaTime, 0f, 0f);  //makes player run left

        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
           
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        }
        
    }
    //calling when player falls below 0 hp
    public void Die()
    {
        Destroy(this.gameObject);
    }
    //display when player is alive
    private void OnEnable()
    {
        collect.SetActive(true);
       
    }
    //display when player is dead
    private void OnDisable()
    {
        //when the player has died change text
        collect.GetComponent<Text>().text = "you have died";
    }
}

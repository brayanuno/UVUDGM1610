using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimal : MonoBehaviour
{
    public GameObject player;
    public GameObject collect;
    public PowerUps powerUps;

    public int playerSpeed = 4;
    public int jumpHeight = 5;

    private bool grounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask WhatIsGround;

    private void Start()
    {
       
    }
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,WhatIsGround);
    }

    void Update()
    {
        //JUMPING
        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            Jump();
        }
        //MOVING LEFT
        if(Input.GetKey(KeyCode.A)) {
            MovingLeft();
        }

        //MOVING RIGHT
        else if(Input.GetKey(KeyCode.D))
        {
            MovingRight();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(powerUps.UsePower(1));
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(powerUps.UsePower(2));
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(powerUps.UsePower(3));
        }

    }
    //calling when player falls below 0 hp
    public void Die()
    {
            print("dead");
            Destroy(player);
     
    }

    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }

    public void MovingRight()
    {
      
            transform.Translate(playerSpeed * Time.deltaTime, 0f, 0f);  //makes player run right

      
    }
    public void MovingLeft()
    {
        transform.Translate(-playerSpeed * Time.deltaTime, 0f, 0f);  //makes player run left
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

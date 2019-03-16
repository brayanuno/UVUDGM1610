using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimal : MonoBehaviour
{
    private Animator animator;
    public GameObject player;
    public GameObject collect;
    public PowerUps powerUps;
    private PlayerBehaviour playerBehaviour;

    public float playerSpeed ;
    public int jumpHeight = 50;

    public bool jump;

    public bool move;
    bool B_FacingRight = true;
    private Rigidbody2D rb;


    private void Awake()
    {
        
    }

    private void Start()
    {
        move = true;
        playerSpeed = 9f; //playerSpeed
        jump = true;
        animator = this.transform.Find("PlayerModel").GetComponent<Animator>();
        playerBehaviour = GetComponent<PlayerBehaviour>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //JUMPING
        if (Input.GetKeyDown(KeyCode.W))
        {
            if(jump == true)
            {
                Jump();
              
                jump = false;   
            }
         
        }
        //MOVING LEFT
        if(Input.GetKey(KeyCode.A)) {
            
                MovingLeft();
        }
        

        //MOVING RIGHT
        if(Input.GetKey(KeyCode.D))
        {
                MovingRight();
        }

        //USE RIGHT CLICK
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //animator.SetTrigger("Attack2");
        }

            //USE LEFT CLICK
        if (Input.GetKeyDown(KeyCode.Mouse0) )
        {
            animator.SetTrigger("Attack");
        }
        

        //USE POWER 1
        if (Input.GetKeyDown(KeyCode.Z) && powerUps.disablePower[0] == true)
        {
            StartCoroutine(powerUps.UsePower(1));
        }
        // USE POWER 2
        if (Input.GetKeyDown(KeyCode.X) && powerUps.disablePower[1] == true)
        {
            StartCoroutine(powerUps.UsePower(2));
        }
        // USE POWER 3
        if (Input.GetKeyDown(KeyCode.C) && powerUps.disablePower[2] == true)
        {
            StartCoroutine(powerUps.UsePower(3));
        }

        //changin to run and idle animations
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f)
            animator.SetFloat("MoveSpeed", 0.6f); //running
        else
            animator.SetFloat("MoveSpeed", 0f); //idle
    }

    //when player touch the ground
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Enemy")
        {
            jump = true;
        }
    }

    //calling when player falls below 0 hp
    public void Die()
    {
            animator.Play("Die");
            Destroy(player);
            Destroy(GameObject.Find("Canvas"));
    }

    public void Jump()
    {
        rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
    }

    public void MovingRight()
    {
        transform.Translate(playerSpeed * Time.deltaTime, 0f, 0f);  //makes player run right

        if (!B_FacingRight)
        {
            Flip();
        }
    }
    public void MovingLeft()
    {
        
        transform.Translate(-playerSpeed * Time.deltaTime, 0f, 0f);  //makes player run left
        if (B_FacingRight)
        {
            Flip();
        }
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

    //flipping the character to the direction
    private void Flip()
    {
        B_FacingRight = !B_FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1; //flip
        this.transform.localScale = theScale;
    }

    private void PrefabCharacter()
    {

    }
}

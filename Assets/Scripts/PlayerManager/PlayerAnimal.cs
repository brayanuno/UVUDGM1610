using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimal : MonoBehaviour
{
    private Animator animator;
    //public PowerUps powerUps;
    private PlayerBehaviour playerBehaviour;
    private PowerUps powerUps;
    [SerializeField] private InGameCharacter inGameCharacter;
    [SerializeField] private PlayerInfo playerInfo;

    public float playerSpeed;
    public float jumpHeight;

    public bool jump;
    public bool move;
    bool B_FacingRight = true;
    private Rigidbody2D rb;

    private void Start()
    {
        playerInfo = PlayerInfo.instance;
        animator = transform.Find("PlayerModel").GetComponent<Animator>();
        playerBehaviour = GetComponent<PlayerBehaviour>();
        rb = GetComponent<Rigidbody2D>();
        powerUps = GameObject.Find("GamePlayManager").GetComponent<PowerUps>();  
        move = true;
        jump = true;
    }

    void FixedUpdate()
    {
        if (!playerInfo.restartStats) //false
         {
            return;
         } else
         {
            jumpHeight = playerInfo.jumpHeight;
            playerSpeed = playerInfo.speedPlayer;
         }
      
    }

    void Update()
    {
        //JUMPING
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(jump == true)
            {
                Jump();
              
                jump = false;   
            }     
        }
        //MOVING LEFT
        if (Input.GetKey(KeyCode.A))
        {

            MovingLeft();
        }

        //MOVING RIGHT
        if (Input.GetKey(KeyCode.D))
        {
            MovingRight();
        }

        //ACTIVE STORE AND DESACTIVE
        if (Input.GetKeyDown(KeyCode.Q))
        {
            print("workingkey");
            Store.instance.GetComponent<Store>().OpenStore();//call the store to activate
            //Inventory.instance.GetComponent<Inventory>().Exit();
        }
        //ACTIVE STORE AND DESACTIVE
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            
            Inventory.instance.OpenInventory(); //call the store to activate
            //Store.instance.GetComponent<Store>().Exit();
        }

        //USE RIGHT CLICK
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //animator.SetTrigger("Attack2");
        }

        //USE LEFT CLICK TO ATTACK
        if (Input.GetKeyDown(KeyCode.Mouse0) )
        {
            animator.SetTrigger("Attack");
        }

        //changin to run and idle animations
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f)
            animator.SetFloat("MoveSpeed", 0.6f); //running
        else
            animator.SetFloat("MoveSpeed", 0f); //idle


        //USING FIRST POWERUP
        if (Input.GetKeyDown(KeyCode.Z))
        {
            powerUps.PowerUp(0);
        }

        //USING SECOND POWERUP
        else if (Input.GetKeyDown(KeyCode.X))
        {
            powerUps.PowerUp(1);
        }

        //USING THIRD POWERUP
        else if (Input.GetKeyDown(KeyCode.C))
        {
            powerUps.PowerUp(2);
        }
    }

    //when player touch the ground or the enemy
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
            //animator.Play("Die");
           // Destroy(this);
            //Destroy(GameObject.Find("Canvas"));
    }

    public void Jump()
    {
        rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
    }

    public void MovingRight()
    {
        transform.Translate(playerSpeed * Time.deltaTime, 0f, 0f);  //makes player run right
        //rb.AddForce(Vector2.right * playerSpeed * Time.deltaTime);
        if (!B_FacingRight)
        {
            Flip();
        }
    }
    public void MovingLeft()
    {
        transform.Translate(-playerSpeed * Time.deltaTime, 0f, 0f);  //makes player run left
        //rb.AddForce(-Vector2.right * playerSpeed * Time.deltaTime);
        if (B_FacingRight)
        {
            Flip();
        }
    }
    
    //flipping the character to the direction
    private void Flip()
    {
        B_FacingRight = !B_FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1; //flip
        this.transform.localScale = theScale;
    }
}

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

    private bool canMove;
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
        if (Inventory.instance.GetComponent<Inventory>().gameObject.activeInHierarchy ||
               Store.instance.GetComponent<Store>().gameObject.activeInHierarchy)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }
    
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
        if (Input.GetKeyDown(KeyCode.Space) && canMove)
        {
            if(jump == true)
            {
                Jump();
              
                jump = false;   
            }     
        }
        //MOVING LEFT
        if (Input.GetKey(KeyCode.A) && canMove)
        {

            MovingLeft();
        }

        //MOVING RIGHT
        if (Input.GetKey(KeyCode.D) && canMove)
        {
            MovingRight();
        }

        //ACTIVE STORE AND DESACTIVE
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Store.instance.GetComponent<Store>().OpenStore();   
        }

        //ACTIVE STORE AND DESACTIVE
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //Inventory.instance.GetComponent<Inventory>().OpenInventory(); 
        }

        //USE RIGHT CLICK TO CLICK ATTACK 2
        if (Input.GetKeyDown(KeyCode.Mouse1) && playerBehaviour.rangeDelay == true && canMove)
        {
            animator.SetTrigger("Attack2");
            StartCoroutine(playerBehaviour.Shooting());
        }

        //USE LEFT CLICK TO ATTACK
        if (Input.GetKeyDown(KeyCode.Mouse0) && canMove )
        {
            animator.SetTrigger("Attack");
        }

        //changin to run and idle animations
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f && canMove)
            animator.SetFloat("MoveSpeed", 0.6f); //running
        else
            animator.SetFloat("MoveSpeed", 0f); //idle


        //USING FIRST POWERUP
        if (Input.GetKeyDown(KeyCode.Z) && canMove)
        {
            powerUps.PowerUp(0);
        }

        //USING SECOND POWERUP
        else if (Input.GetKeyDown(KeyCode.X) && canMove)
        {
            powerUps.PowerUp(1);
        }

        //USING THIRD POWERUP
        else if (Input.GetKeyDown(KeyCode.C) && canMove)
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
    
    //flipping the character to the direction
    private void Flip()
    {
        B_FacingRight = !B_FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1; //flip
        this.transform.localScale = theScale;
    }
}

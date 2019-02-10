using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public GameObject player;
    public float playerSpeed;
    private Rigidbody rb;//allows us to be able to change speed in Unity
    private int jumpCount;
    private bool grounded;
    private float jumpDelay = 3.0f;
    public Collider headCollider;
    //public Vector2 jumpHeight;
    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerSpeed = 2f;
        //limit the jump to two
        jumpCount = 0;
        grounded = false;

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(playerSpeed * Time.deltaTime, 0f, 0f);  //makes player run right

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-playerSpeed * Time.deltaTime, 0f, 0f);  //makes player run left

        }
     

        if (Input.GetKeyDown(KeyCode.Space) && (jumpCount < 2))  //makes player jump
        {
            rb.velocity = new Vector3(0f, 5f, 0f);
            jumpCount++;
            print(jumpCount);

        }
 

    }
    //when colliding with the floor reset the max jump
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Terrain")
        {
            jumpCount = 0;
            print("colliding working");
        }
    }

    


}

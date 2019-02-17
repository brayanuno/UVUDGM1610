using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    public float playerSpeed;

    [SerializeField]
    private Powers power;

    private Rigidbody rb;
    private int jumpCount;
    //public Vector2 jumpHeight;

    private string[] powers;
    private int powerAvailable;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerSpeed = 4f;
        //limit the jump to two
        jumpCount = 0;
        powers = new string[3];
        powers[0] = "freeze";
        powers[1] = "timer";
        powers[2] = "invisible";
        powerAvailable = 3;


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
        }

        //input the first power
        if (Input.GetKeyDown(KeyCode.B))
        {
            power.ReleasePower(powers[0]);
            powerAvailable--;
           
        }
        //input the second power
        if (Input.GetKeyDown(KeyCode.N))
        {
            power.ReleasePower(powers[1]);
            powerAvailable--;
    
        }
        //input the third power
        if (Input.GetKeyDown(KeyCode.M))
        {
            power.ReleasePower(powers[2]);
            powerAvailable--;

        }


        //preventing from falling
        Vector3 rotationVector = transform.rotation.eulerAngles;
        rotationVector.x = 0;
        rotationVector.z = 0;
        transform.rotation = Quaternion.Euler(rotationVector);


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

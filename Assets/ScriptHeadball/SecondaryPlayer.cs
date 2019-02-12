using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    public float playerSpeed;

    private Rigidbody rb;
    private int jumpCount;
    //public Vector2 jumpHeight;
    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerSpeed = 4f;
        //limit the jump to two
        jumpCount = 0;

    }
    // Update is called once per frame
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


        if (Input.GetKeyDown(KeyCode.S) && (jumpCount < 2))  //makes player jump
        {
            rb.velocity = new Vector3(0f, 5f, 0f);
            jumpCount++;

        }

        //previnting from falling
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject ball;
    private Rigidbody rb;

    [SerializeField]
    private GamePlay gameplay;

    private int headForce = 700;
    private int footForce = 900;
    void Start()
    {

    }

    private void OnCollisionEnter(Collision col)
    {
        //if the ball touch the head add force to the ball
        if (col.contacts[0].otherCollider.transform.gameObject.name == "HeadCollider")
        {
            ball.GetComponent<Rigidbody>().AddForce(transform.right * headForce);
         

        }
        //if the ball touch the foot add force to the ball
        if (col.contacts[0].otherCollider.transform.gameObject.name == "FootCollider")
        {
            ball.GetComponent<Rigidbody>().AddForce(transform.right * footForce);
           
        }

        if (col.contacts[0].otherCollider.transform.gameObject.name == "HeadColliderSecond")
        {
            print("working");
            ball.GetComponent<Rigidbody>().AddForce(Vector3.left * headForce);


        }
        if (col.contacts[0].otherCollider.transform.gameObject.name == "FootColliderSecond")
        {
            print("working");
            ball.GetComponent<Rigidbody>().AddForce(Vector3.left * headForce);

        }
    }
    //
    public void InvokingForce()
    {
        ball.GetComponent<Rigidbody>().AddForce(transform.right * headForce);

    }
}

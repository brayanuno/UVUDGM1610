using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public Vector3 offset;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        /// getting the distance between the player's position and camera's position
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //setting the camera as the smae of the player camera but with a offet calculated at top
        transform.position = player.transform.position + offset;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScript : MonoBehaviour { 

    [SerializeField]
    private int waterBottle = 60;

    // Start is called before the first frame update
    void Start()
    {
        print(waterBottle);
    }

    // Update is called once per frame
    void Update()
    {
        //print(waterBottle);
    }
}


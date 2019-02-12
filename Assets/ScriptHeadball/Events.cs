using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{   
    public UnityEngine.Events.UnityEvent Triggering;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            Triggering.Invoke();
            print("event working");
        }
    }
}

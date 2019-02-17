using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : Player
{
    private int powercount;

    public GameObject image;
    public GameObject freezeObject;



    void Start()
    {
        //setting the powers
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //when player release a power
    public void ReleasePower(string name)
    {
        switch (name)
        {
            case "freeze":
                FreezePower();
                break;
            case "timer":
                TimerPower();
                break;
            case "invisible":
                invisiblePower();
                break;

        }
    }

    public void FreezePower()
    {
        StartCoroutine(ShowAndHide(freezeObject, 4.0f)); 
    }

    public void TimerPower()
    {
        StartCoroutine("WaitUnhide");
        print("you used Timer ");
    }

    public void invisiblePower()
    {
        StartCoroutine("WaitUnhide");
        print("you used invisible");

    }

    IEnumerator ShowAndHide(GameObject prefab, float delay)
    {
        prefab.SetActive(true);
        yield return new WaitForSeconds(delay);
        prefab.SetActive(false);
    }
}

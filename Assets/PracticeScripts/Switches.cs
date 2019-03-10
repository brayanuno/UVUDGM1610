using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switches : MonoBehaviour
{

    public string suspect;

    public string weapon;

    public string room;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        MysteryCrimen(suspect);

    }
    private void MysteryCrimen(string name)
    {
        switch (name)
        {
            case "wero":
                print("wero is suspect");
                break;
            case "pint":
                print("pint is suspect");
                break;
            case "tempo":
                print("tempo is suspect");
                break;
            case "jaime":
                print("jaime is suspect");
                break;
            case "ronald":
                print("ronald is suspect");
                break;
            case "brayan":
                print("brayan is suspect");
                break;
            case "snitch":
                print("snitch is suspect");
                break;
            case "javier":
                print("javier is suspect");
                break;
            case "mario":
            case "juan":
                print("Mario and Juan is suspect");
                break;
            default:
                print("none suspect");
                break;
        }
    }
}

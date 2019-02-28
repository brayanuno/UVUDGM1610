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
                print("wero is suspect");
                break;
            case "tempo":
                print("wero is suspect");
                break;

            default:
                print("none suspect");
                break;...........................
        }
    }
}

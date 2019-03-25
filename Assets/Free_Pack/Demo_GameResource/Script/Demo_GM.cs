using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum CharacterID
{
    NONE,
    Knight,
    m_wizard,
    Priest,
    Samurai,
    Gunner,
    Elf,
    W_Wizard,
    M_Archer


}

public class Demo_GM : MonoBehaviour {




    public CharacterID characterid = CharacterID.Knight;

    public static Demo_GM Gm;

    public Image[] UIImage;

    public RectTransform Pointer;
    public RectTransform CanvasUIRect;
    // Use this for initialization
    void Awake () {
        Gm = this;
        Color myColor = new Color32(180, 180, 180, 255);
        UIImage[0].color = myColor;
        Screen.fullScreen = false;
       
    }
	
	// Update is called once per frame
	void Update () {

        KeyUPDownchange();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("F1_Knight");

            characterid = CharacterID.Knight;
            InitColor();
            Color myColor = new Color32(180,180,180,255);
         
            UIImage[0].color = myColor;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("F2_m_wizard");

            characterid = CharacterID.m_wizard;

            InitColor();
            Color myColor = new Color32(180, 180, 180, 255);

            UIImage[1].color = myColor;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("F3_Priest");

            characterid = CharacterID.Priest;
            InitColor();
            Color myColor = new Color32(180, 180, 180, 255);

            UIImage[2].color = myColor;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("F4_Samurai");

            characterid = CharacterID.Samurai;
            InitColor();
            Color myColor = new Color32(180, 180, 180, 255);

            UIImage[3].color = myColor;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("F5_Gunner");

            characterid = CharacterID.Gunner;
            InitColor();
            Color myColor = new Color32(180, 180, 180, 255);

            UIImage[4].color = myColor;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Debug.Log("F6_Elf");

            characterid = CharacterID.Elf;
            InitColor();
            Color myColor = new Color32(180, 180, 180, 255);

            UIImage[5].color = myColor;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Debug.Log("F7_W_Wizard");

            characterid = CharacterID.W_Wizard;
            InitColor();
            Color myColor = new Color32(180, 180, 180, 255);

            UIImage[6].color = myColor;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Debug.Log("F8_M_Archer");

            characterid = CharacterID.M_Archer;
            InitColor();
            Color myColor = new Color32(180, 180, 180, 255);

            UIImage[7].color = myColor;
        }

    }


    void InitColor()
    {

        for (int i = 0; i < UIImage.Length; i++)
        {
            UIImage[i].color = new Color(255, 255, 255);


        }

    }

    public void KeyUPDownchange()
    {
        // wsad
        if (Input.GetKeyUp(KeyCode.A))
        {
            Color myColor = new Color32(255, 255, 255, 255);

            Demo_GM.Gm.UIImage[12].color = myColor;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            Color myColor = new Color32(255, 255, 255, 255);

            Demo_GM.Gm.UIImage[13].color = myColor;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            Color myColor = new Color32(255, 255, 255, 255);

            Demo_GM.Gm.UIImage[10].color = myColor;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            Color myColor = new Color32(255, 255, 255, 255);

            Demo_GM.Gm.UIImage[11].color = myColor;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Color myColor = new Color32(180, 180, 180, 255);

            Demo_GM.Gm.UIImage[12].color = myColor;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Color myColor = new Color32(180, 180, 180, 255);

            Demo_GM.Gm.UIImage[13].color = myColor;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Color myColor = new Color32(180, 180, 180, 255);

            Demo_GM.Gm.UIImage[10].color = myColor;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Color myColor = new Color32(180, 180, 180, 255);

            Demo_GM.Gm.UIImage[11].color = myColor;
        }

        ///
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Color myColor = new Color32(255, 255, 255, 255);

            Demo_GM.Gm.UIImage[14].color = myColor;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Color myColor = new Color32(255, 255, 255, 255);

            Demo_GM.Gm.UIImage[15].color = myColor;
        }

      


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            Color myColor = new Color32(180, 180, 180, 255);

            Demo_GM.Gm.UIImage[14].color = myColor;

        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {



            Color myColor = new Color32(180, 180, 180, 255);

            Demo_GM.Gm.UIImage[15].color = myColor;

        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {


            Color myColor = new Color32(180, 180, 180, 255);

            Demo_GM.Gm.UIImage[8].color = myColor;
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {

            Color myColor = new Color32(180, 180, 180, 255);

            Demo_GM.Gm.UIImage[9].color = myColor;
        }


        if (Input.GetKeyUp(KeyCode.Alpha9))
        {


            Color myColor = new Color32(255, 255, 255, 255);

            Demo_GM.Gm.UIImage[8].color = myColor;
        }

        if (Input.GetKeyUp(KeyCode.Alpha0))
        {

            Color myColor = new Color32(255, 255, 255, 255);

            Demo_GM.Gm.UIImage[9].color = myColor;
        }

    }

}

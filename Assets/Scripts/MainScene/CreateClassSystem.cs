using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreateClassSystem : MonoBehaviour
{
    public InputField usernameInput;
    private string username;
    public Toggle isDefault;
    public Toggle isKnight;
    public Toggle isWizard;
    public Toggle isSamurai;
    public Toggle isWomanWizard;
    public Button startButton;
    public LevelLoader levelLoad;
    public InGameCharacter newCharacter;

    public GameObject[] HoverImages;

    //base the stats of every Character\
    private string nameCharacter;
    private int hitpoint;
    private int attackRange;
    private float radarplayer;
    private float speedplayer;
    private float jumpHeight;
    private int damage;


    void Awake()
    {
        //this is the Chracter maanager cannot be destroy to send data to another scenes
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        //inGameCharacter = gameObject.GetComponent<InGameCharacter>();
        foreach(GameObject obj in HoverImages)
        {
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DontDestroyOnLoad(this);
        username = usernameInput.text;
        CharacterSelection();
        checkingEmptyUsername();
    }

    public void checkingEmptyUsername()
    {
        if (usernameInput.text == "")
        {
           startButton.GetComponent<Button>().interactable = false;
        } else
        {
            startButton.GetComponent<Button>().interactable = true;
        }
    }

    public void CharacterSelection () {

        if (isDefault.isOn)
        {
            CharacterCreation(0); //Default Character
        }
        if (isKnight.isOn)
        {
            CharacterCreation(1); //Knight Character
        }
        if (isWizard.isOn)
        {
            CharacterCreation(2);
        }
        if (isSamurai.isOn)
        {
            CharacterCreation(3);
        }
        if (isWomanWizard.isOn)
        {
            CharacterCreation(4);
        }
    }
    //creating the character
    public void CharacterCreation(int index)
    {
        switch (index) {
            case 0:
                newCharacter = new InGameCharacter(0,username, 120, 10f, 15, 8f, 40f);
                break;
            case 1:
                newCharacter = new InGameCharacter(1,username, 150, 8f, 13, 6f, 30f);

                break;
            case 2:
                newCharacter = new InGameCharacter(2,username,200, 12f,10, 7f, 20f);
                break;
            case 3:
                newCharacter = new InGameCharacter(3, username, 180, 8f, 12, 8f, 30f);
                break;
            case 4:
                newCharacter = new InGameCharacter(4, username, 130, 12f, 14, 6f, 35f);
                break;
        }
    }
    //base stats for all the hearoes available 
    public void baseStats(int index)
    {
        switch (index) {
            case 0:
                nameCharacter = "Default";
                hitpoint = 120;
                attackRange = 5;
                radarplayer = 10f;
                speedplayer = 8;
                jumpHeight = 40;
                damage = 15;
                break;
            case 1:
                nameCharacter = "Knight";
                hitpoint = 150;
                attackRange = 4;
                radarplayer = 8f;
                speedplayer = 6;
                jumpHeight = 30;
                damage = 13;
                break;
            case 2:
                nameCharacter = "Wizard";
                hitpoint = 200;
                attackRange = 5;
                radarplayer = 12f;
                speedplayer = 7;
                jumpHeight = 20;
                damage = 10;
                break;
            case 3:
                nameCharacter = "Samurai";
                hitpoint = 180;
                attackRange =5;
                radarplayer = 8f;
                speedplayer = 8;
                jumpHeight = 30;
                damage = 12;
                break;
            case 4:
                nameCharacter = "WomanWizard";
                hitpoint = 130;
                attackRange = 6;
                radarplayer = 12f;
                speedplayer = 6;
                jumpHeight = 35;
                damage = 14;
                break;
        }

        for(int i = 0; i < HoverImages.Length; i++)
        {
            HoverImages[index].transform.Find("Name").GetComponent<Text>().text = nameCharacter.ToString();
            HoverImages[index].transform.Find("HitPoint").GetComponent<Text>().text = "HitPoint: " + hitpoint.ToString();
            HoverImages[index].transform.Find("AttackRange").GetComponent<Text>().text = "AttackRange: " + attackRange.ToString();
            HoverImages[index].transform.Find("RadarPlayer").GetComponent<Text>().text = "Radar: " + radarplayer.ToString();
            HoverImages[index].transform.Find("SpeedPlayer").GetComponent<Text>().text = "Speed: " + speedplayer.ToString();
            HoverImages[index].transform.Find("JumpHeight").GetComponent<Text>().text = "JumpHeight: " + jumpHeight.ToString();
            HoverImages[index].transform.Find("Damage").GetComponent<Text>().text = "Damage: " + damage.ToString();
        }
    }


    //hovering display stats
    public void OnPointer(int index) //0
    {
        baseStats(index);
        HoverImages[index].SetActive(true); //getting information to the hover image
    }

    //inactive stats
    public void OnPointerExit(int index)
    {
        HoverImages[index ].SetActive(false);

    }
}

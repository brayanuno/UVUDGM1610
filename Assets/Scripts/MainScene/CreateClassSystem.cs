using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateClassSystem : MonoBehaviour
{
    public InputField usernameInput;
    private string username;
    public Toggle isWarrior;
    public Toggle isMage;
    public Toggle isPriest;
    public Button startButton;
    public LevelLoader levelLoad;
    private InGameCharacter newCharacter;

    // Start is called before the first frame update
    void Start()
    {
        //inGameCharacter = gameObject.GetComponent<InGameCharacter>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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

        if (isWarrior.isOn)
        {
            CharacterCreation(1);
        }
        if (isMage.isOn)
        {
            CharacterCreation(2);
        }
        if (isPriest.isOn)
        {
            CharacterCreation(3);
        }       
    }


    public void CharacterCreation(int index)
    {
        switch (index) {
            
            case 1:
                newCharacter = new InGameCharacter(username,100, 20f, 20, 20f, 60f);

                break;
            case 2:
                newCharacter = new InGameCharacter(username, 200, 30f, 42f, 12f, 60f);

                break;
            case 3:
                newCharacter = new InGameCharacter(username,300, 40f,  5f, 32f, 60f);
                break;
        }
        
    }

    public void StartButton()
    {
        
        levelLoad.LoadLvel(1); //load the level 
    }

}

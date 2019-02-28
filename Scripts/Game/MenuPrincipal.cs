using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour  
{
    //instance
    
    //public variables
    public GameObject canvasInput;
    public GameObject canvasMenu;
    public GameObject heroes;
    public GameObject LobbyHero;

    public InputField inputField;

    [SerializeField]
    private Text username;

    //Resources availables
    [SerializeField]
    public Text stamina;
    [SerializeField]
    public Text gold;
    [SerializeField]
    public Text diamond;

    //currency actual
    [SerializeField]
    public static int soulShardAmount;
    [SerializeField]
    public static int goldAmount;
    [SerializeField]
    public static int diamondAmount;



    void Start()
    {
        canvasInput.SetActive(true);
        canvasMenu.SetActive(false);
        heroes.SetActive(false);
        LobbyHero.SetActive(false);

        soulShardAmount = 60;
        goldAmount = 50000;
        diamondAmount = 30000;
        DisplayingResources();

    }


    void Update()
    {
        if (inputField.text != "" && Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
        {
            canvasInput.SetActive(false);
            canvasMenu.SetActive(true); 
            username.text = inputField.text;

        }
    }
    
    /// displaying the stamina
    public void DisplayingResources()
    {
        stamina.text = soulShardAmount.ToString();
        gold.text = goldAmount.ToString();
        diamond.text = diamondAmount.ToString(); ;
    }
 
    // showing and hiding Heroes Section
    public void ShowHeroes()
    {
        canvasMenu.SetActive(false);
        heroes.SetActive(true);
    }

    public void OutOfResources(int resource)
    {

    }
 }

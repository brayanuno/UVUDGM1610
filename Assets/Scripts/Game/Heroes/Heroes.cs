using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heroes: MonoBehaviour
{
    public GameObject heroes;

    public GameObject heroList;
    public GameObject heroManual;
    public GameObject heroShard;
    public GameObject exit;
    public GameObject about;

    public GameObject maxSlot;

    public Text diamond;
    public Text gold;

    //currency actual
    private int diamondAmount;
    private int goldAmount;

    public GameObject confirmationBuyHero;
  
    private bool confirmationBuyHeroEnabled;

    public GameObject menuPrincipal;

    public GameObject[] heroesCount;

    //private bool onActive;

    // Start is called before the first frame update
    void Start()
    {
        confirmationBuyHero.SetActive(false);
        maxSlot.SetActive(false);


        diamondAmount = MenuPrincipal.diamondAmount;
        goldAmount = MenuPrincipal.goldAmount;

        diamond.text = diamondAmount.ToString();
        gold.text = goldAmount.ToString();
        onHeroList();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    //exit to menu
    public void goBackMenu()
    {
        menuPrincipal.SetActive(true);
        heroes.SetActive(false);
    }

    //activate canvas ConfirmationBuyHero
    public void BuyHeroConfirmation()
    {
       // enabled and disabling confirmation
        confirmationBuyHeroEnabled = !confirmationBuyHeroEnabled;
      
        if (confirmationBuyHeroEnabled)
        {
            confirmationBuyHero.SetActive(true);
        }
        else
        {
            confirmationBuyHero.SetActive(false); 
        }
       

    //Attaching new Resources to heroes
    }

    public void UpdatingheroesResources(int diamond)
    {
        diamondAmount -= diamond;
        this.diamond.text = diamondAmount.ToString();
    }

    //heroList.GetComponentInChildren<Text>();
    public void onHeroList()
    {
        //changing color in active
        heroList.GetComponent<Image>().color = Color.green;
        heroList.GetComponentInChildren<Text>().color = Color.white;

    }


    public void onHeroManual()
    {
        heroShard.SetActive(false);
        heroManual.SetActive(true);
        heroList.SetActive(false);
    }
    public void onShard()
    {
        heroShard.SetActive(true);
        heroManual.SetActive(false);
        heroList.SetActive(false);

    }
}

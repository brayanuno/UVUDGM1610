using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroeList : MonoBehaviour
{
    //a prefab image
    public GameObject buttonPrefab;

    [SerializeField]
    private ConfirmationBuyHeroSlot ConfirmationBuyHeroSlot;
    [SerializeField]
    private HeroManual heroManual;

    public Text heroSlots;
    //inventory heroes Amount
    public int heroesMaxSlot;
    private int heroesOwn;
    private int initialNewSlot = 10;
    private bool newHero;
    private int id = 1;
     void Start()
    {
        heroesOwn = 0;
        heroesMaxSlot = 0;
        //starting with the heroesMaxSlot of 10 
        CreatingNewSlots(initialNewSlot);
        //starting with 10 heroes Slots in the game
        
    }
    
    public void NewHero()
    {
       if(heroesOwn <= heroesMaxSlot)
       {

            heroesOwn += 1;
            heroSlots.text = heroesOwn.ToString() + " / " + heroesMaxSlot.ToString();
            
            HeroManual hero1 = new HeroManual("brayan", 3, 10000, 300, 400, 300, "assasin", "the enemyAttacks two Random Enemies by 230%", "increase hp by 10% and attack by 20%", "basic attack deals 145%", "every enemy died gain 20% hp");
        }
    }
    //placing new hero
    public void GotNewHero(int id)
    {
        if (heroesOwn <= heroesMaxSlot)
        {
            buttonPrefab.GetComponentInChildren<Text>().text = "this is the new hero with id 1 ";
            //creating a new hero with the id 1
            heroManual.HeroesStats(id);
            heroesOwn += 1;
            buttonPrefab.GetComponentInChildren<Text>().text = "Some string";
            
            heroSlots.text = heroesOwn.ToString() + " / " + heroesMaxSlot.ToString();
        }
    }

    private void DisplayingHeroLobby ()
    {

    }
    
    
    //creating new prefabs 

    public void CreatingNewSlots(int slot)
    {
        GameObject newPrefabSlot;

        for (int i = 0; i < slot; i++)
        {
            heroesMaxSlot++;
            newPrefabSlot = (GameObject)Instantiate(buttonPrefab, transform);

  
            newPrefabSlot.GetComponent<Image>().color = Random.ColorHSV();
            heroSlots.text = heroesOwn.ToString() + " / " + heroesMaxSlot.ToString();

        }
    }
    //getting the heroess by id
    
}

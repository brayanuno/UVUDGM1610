using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HeroeList : MonoBehaviour
{
    public GameObject buttonPrefab;
    [SerializeField]
    private ConfirmationBuyHeroSlot ConfirmationBuyHeroSlot;
    [SerializeField]
    private GameObject heroLobby;
    [SerializeField]
    private HeroLobby heroLobbyInstance;

    public HeroeList heroeList;
    public HeroManual heroManualInstance;

    private List<GameObject> heroeLists = new List<GameObject>();

    public Text heroSlots;
    //inventory heroes Amount
    public int heroesMaxSlot;
    
    public int heroesOwn;
    private int initialNewSlot;

    //new heroes information
    private int id;
    private string name;
    private int stars;
    private int health;
    private int attack;
    private int armor;
    private int speed;

    private string primarySkill;
    private string passiveSkill;
    private string secondaryPassiveSkill;
    private string lastPassiveSkill;
    private string role;


    private 
   
    //creating new heroes and storing information

     void Start()

    {
        initialNewSlot = 10;
        heroesOwn = 0;
        heroesMaxSlot = 0;
        //starting with the heroesMaxSlot of 10 
        CreatingNewSlots(initialNewSlot);
        heroSlots.text = heroesOwn.ToString() + " / " + heroesMaxSlot.ToString();

    }

    //new Hero button
    public void NewHero()
    {
        
        if (heroesOwn < heroesMaxSlot)
        {         
            //getting the information of the hero
            //int idNumber = Random.Range(1, 10);
            //print(idNumber);
            //heroManualInstance.herobyId(idNumber);
            //string name = heroManualInstance.heroManual.name;
            //print(name);
            int idNumber = Random.Range(1, 10);
            heroManualInstance.herobyId(idNumber);

            GameObject newPrefabSlot = Instantiate(buttonPrefab, transform);
            
            heroLobbyInstance.heroInfo(heroManualInstance.heroManual.id, heroManualInstance.heroManual.name, heroManualInstance.heroManual.stars, heroManualInstance.heroManual.health,
                        heroManualInstance.heroManual.attack, heroManualInstance.heroManual.armor, heroManualInstance.heroManual.speed, heroManualInstance.heroManual.role, heroManualInstance.heroManual.primarySkill,
                         heroManualInstance.heroManual.passiveSkill, heroManualInstance.heroManual.secondaryPassiveSkill, heroManualInstance.heroManual.lastPassiveSkill);

            newPrefabSlot.name = heroManualInstance.heroManual.name;
            Button buttonCtrl = newPrefabSlot.GetComponent<Button>();

            Text ButtonText = buttonCtrl.GetComponentInChildren<Text>();
            ButtonText.text = heroManualInstance.heroManual.attack.ToString();

            buttonCtrl.onClick.AddListener(() => PrefabWasClicked());
            heroeLists.Add(newPrefabSlot);

            print(heroeLists[0]);
            print(heroeLists.Count);
            //print(firstItem);      
            heroesOwn++;
            heroSlots.text = heroesOwn.ToString() + " / " + heroesMaxSlot.ToString();
        }
        else
        {
            //no enough space in the slots
            print("no enough space");

        }

    }

    //everything the prefab was clicked 
    public void PrefabWasClicked() {
       
        heroLobby.SetActive(true);
    }

    //creating new slots but not visible

    public void CreatingNewSlots(int slot)
    {
        
        for (int i = 0; i < slot; i++)
        {
            heroesMaxSlot++;
            //newPrefabSlot = (GameObject)Instantiate(buttonPrefab, transform);
            //newPrefabSlot.GetComponent<Image>().color = Random.ColorHSV();
            heroSlots.text = heroesOwn.ToString() + " / " + heroesMaxSlot.ToString();

        }
    }

    
    
}

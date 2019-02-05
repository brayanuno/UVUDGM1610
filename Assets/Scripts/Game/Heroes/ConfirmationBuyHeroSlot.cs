using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationBuyHeroSlot : MonoBehaviour

{
    public GameObject confirmationBuyHeroSlot;
    public Button buy;
    public GameObject content;
    private int contentHeight;
    

    //instances
    public MenuPrincipal menuPrincipal;
    public Heroes heroes;
    public HeroeList heroList;

    [SerializeField]
    private int[]Stages;
    public Text costSlotText;

    private int costSlot;
    private int index ;
    private int amountPerSlot;

    // Start is called before the first frame update
    void Start()
    {
        //Attaching new Resources to heroes
        //cost slot start
        amountPerSlot = 5;
        index = 0;
        costSlot = 100;
        Stages = new int[30];

        for (int i = 0; i < Stages.Length; i++)
        {
            Stages[i] = costSlot * (i+1);
        }

        contentHeight = 5;
    }

    //buying new slots
    public void buySlot()
    {
        //if the player has reached the max slot possibles
        if (index < Stages.Length)
        {
            //If the player have enough diamonds SO buy it
            if (MenuPrincipal.diamondAmount >= Stages[index])
            {
                int diamondLeft = MenuPrincipal.diamondAmount - Stages[index];
                MenuPrincipal.diamondAmount = diamondLeft;
                //setting the new diamond remaining
                menuPrincipal.diamond.text = diamondLeft.ToString();

                heroes.UpdatingheroesResources(Stages[index]);
                index++;
                costSlotText.text = "Buy new 5 Hero slots for " + Stages[index];

                //creating new slots and increasing slots
                heroList.CreatingNewSlots(amountPerSlot);
                confirmationBuyHeroSlot.SetActive(false);

                //increasing the size of the content object
                RectTransform rt = content.GetComponent<RectTransform>();
                rt.sizeDelta = new Vector2(rt.sizeDelta.x, rt.sizeDelta.y + contentHeight);
            }
            else
            {
                costSlotText.text = "NO enough gems";
                buy.interactable = false;
            }
        }
        else {
            heroes.maxSlot.SetActive(true);
            
            
        } 
    }
     
}

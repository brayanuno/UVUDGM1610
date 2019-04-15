using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public static Store instance;
    [SerializeField] private Transform Panel2Slots; //slots bottom
    [SerializeField] private GameObject NoCoinsPanel;
    public Item[] items; //items values
    [SerializeField] private GameObject[] ItemsStore; //items from the store to update
    public GameObject infoStore;
    private ScoreManager scoreManager;
    public GameObject prefab;
    private bool buyOnce = false;
    private bool isOpen = false;

    [SerializeField] private Button[] buttons;
    

    // Start is called before the first frame update
    void Awake()
    {
        gameObject.SetActive(false);
        instance = this;
        UpdateSprite(); //updating spirites in the store
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        NoCoinsPanel.SetActive(false);
    }

    //buying once every item
    public void BuyItem(int index)
    {
        buyOnce = true;
        
        foreach (Transform SlotsTransform in Panel2Slots)
        {
            GameObject item = SlotsTransform.GetComponent<Slot>().item;         
            if (!item) //if there is not an item in the slot
            {
                if (buyOnce)
                {
                    GameObject prefabNew = prefab;
                   
                    if (PriceItem(index))
                    {
                        SlotsTransform.GetComponent<Slot>().AddItem(ItemInfo(index, prefabNew)); //filling the prefab with the itemdata
                        buyOnce = false;
                    }
                }
            }  
        }
    }

    IEnumerator WaitSeconds(float waitTime,GameObject obj)
    {
        NoCoinsPanel.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        NoCoinsPanel.SetActive(false);
    }

    private bool PriceItem(int index)
    {
        bool Available = false;
        switch(index)
        {
            case 0:
                if(scoreManager.score >= items[0].cost)
                {
                    //30 <= 100
                    scoreManager.BuyScore(items[0].cost);
                    Available = true;
                    buttons[0].interactable = false;
                } else
                {
                    StartCoroutine(WaitSeconds(1.5f, NoCoinsPanel));
                }
                break;
            case 1:
                if (scoreManager.score >= items[1].cost)
                {
                    //30 <= 100
                    scoreManager.BuyScore(items[1].cost);
                    Available = true;
                    buttons[1].interactable = false;
                } else
                {
                    StartCoroutine(WaitSeconds(1.5f, NoCoinsPanel));
                }
                break;
            case 2:
                if (scoreManager.score >= items[2].cost)
                {
                    //30 <= 100
                    scoreManager.BuyScore(items[2].cost);
                    Available = true;
                    buttons[2].interactable = false;
                } else
                {
                    StartCoroutine(WaitSeconds(1.5f, NoCoinsPanel));
                }
                break;
            case 3:
                if (scoreManager.score >= items[3].cost)
                {
                    //30 <= 100
                    scoreManager.BuyScore(items[3].cost);
                    Available = true;
                    buttons[3].interactable = false;
                } else
                {
                    StartCoroutine(WaitSeconds(1.5f, NoCoinsPanel));
                }
                break;
            case 4:
                if (scoreManager.score >= items[4].cost)
                {
                    //30 <= 100
                    scoreManager.BuyScore(items[4].cost);
                    Available = true;
                    buttons[4].interactable = false;
                } else
                {
                    StartCoroutine(WaitSeconds(1.5f, NoCoinsPanel));
                }
                break;
            case 5:
                if (scoreManager.score >= items[5].cost)
                {
                    //30 <= 100
                    scoreManager.BuyScore(items[5].cost);
                    Available = true;
                    buttons[5].interactable = false;
                } else
                {
                    StartCoroutine(WaitSeconds(1.5f, NoCoinsPanel));
                }
                break;
        }
        return Available;  
    }

    //assigning overy prefab the to be equal to the item data info
    private GameObject ItemInfo(int index,GameObject obj)
    {
        switch (index)
        {
            case 0:
                obj.GetComponent<PrefabData>().id = items[0].id;
                obj.GetComponent<PrefabData>().itemName = items[0].ItemName;
                obj.GetComponent<PrefabData>().description = items[0].Description;
                obj.GetComponent<PrefabData>().cost = items[0].cost;
                obj.GetComponent<PrefabData>().artWork = items[0].artWork;
                break;
            case 1:
                obj.GetComponent<PrefabData>().id = items[1].id;
                obj.GetComponent<PrefabData>().itemName = items[1].ItemName;
                obj.GetComponent<PrefabData>().description = items[1].Description;
                obj.GetComponent<PrefabData>().cost = items[1].cost;
                obj.GetComponent<PrefabData>().artWork = items[1].artWork;
                break;
            case 2:
                obj.GetComponent<PrefabData>().id = items[2].id;
                obj.GetComponent<PrefabData>().itemName = items[2].ItemName;
                obj.GetComponent<PrefabData>().description = items[2].Description;
                obj.GetComponent<PrefabData>().cost = items[2].cost;
                obj.GetComponent<PrefabData>().artWork = items[2].artWork;
                break;
            case 3:
                obj.GetComponent<PrefabData>().id = items[3].id;
                obj.GetComponent<PrefabData>().itemName = items[3].ItemName;
                obj.GetComponent<PrefabData>().description = items[3].Description;
                obj.GetComponent<PrefabData>().cost = items[3].cost;
                obj.GetComponent<PrefabData>().artWork = items[3].artWork;
                break;
            case 4:
                obj.GetComponent<PrefabData>().id = items[4].id;
                obj.GetComponent<PrefabData>().itemName = items[4].ItemName;
                obj.GetComponent<PrefabData>().description = items[4].Description;
                obj.GetComponent<PrefabData>().cost = items[4].cost;
                obj.GetComponent<PrefabData>().artWork = items[4].artWork;
                break;
            case 5:
                obj.GetComponent<PrefabData>().id = items[5].id;
                obj.GetComponent<PrefabData>().itemName = items[5].ItemName;
                obj.GetComponent<PrefabData>().description = items[5].Description;
                obj.GetComponent<PrefabData>().cost = items[5].cost;
                obj.GetComponent<PrefabData>().artWork =  items[5].artWork;
                break;
        }

        return obj;
    }

    private void UpdateSprite()
    {
        ItemsStore[0].GetComponent<Image>().sprite = items[0].artWork;
        ItemsStore[1].GetComponent<Image>().sprite = items[1].artWork;
        ItemsStore[2].GetComponent<Image>().sprite = items[2].artWork;
        ItemsStore[3].GetComponent<Image>().sprite = items[3].artWork;
        ItemsStore[4].GetComponent<Image>().sprite = items[4].artWork;
        ItemsStore[5].GetComponent<Image>().sprite = items[5].artWork;
    }

    public void OpenStore()
    {
      
     
        if (isOpen)
        {
            gameObject.SetActive(false);
            isOpen = false;
        }
        else
        {
            gameObject.SetActive(true);  
            isOpen = true;
        }

        //if (Inventory.instance.GetComponent<Inventory>().gameObject.activeInHierarchy)
        //
            //Inventory.instance.GetComponent<Inventory>().Exit();
        //}
    }

    public void Exit()
    {
        gameObject.SetActive(false);
    }

    public void InfoOpenStore()
    {
        infoStore.SetActive(true);
    }

    public void InfoCloseStore()
    {
        infoStore.SetActive(false);
    }
}

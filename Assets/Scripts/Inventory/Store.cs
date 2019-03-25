using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public static Store instance;
    public Item[] itemData;
    [SerializeField] private Transform Panel2Slots; //slots bottom

    public Item[] items; //items values
    [SerializeField] private GameObject[] ItemsStore;     //items from the store to update
    public GameObject infoStore;

    public GameObject prefab;
    private bool buyOnce;
    private bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        UpdateSprite(); //updating spirites in the store
        gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

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
                    SlotsTransform.GetComponent<Slot>().AddItem(ItemInfo(index, prefabNew));
                    buyOnce = false;
                }
            }
            
        }
      
    }

    
    private GameObject ItemInfo(int index,GameObject obj)
    {
        switch (index)
        {
            case 0:
                obj.GetComponent<PrefabData>().id = itemData[0].id;
                obj.GetComponent<PrefabData>().itemName = itemData[0].ItemName;
                obj.GetComponent<PrefabData>().description = itemData[0].Description;
                obj.GetComponent<PrefabData>().cost = itemData[0].cost;
                obj.GetComponent<PrefabData>().artWork = itemData[0].artWork;
                break;
            case 1:
                obj.GetComponent<PrefabData>().id = itemData[1].id;
                obj.GetComponent<PrefabData>().itemName = itemData[1].ItemName;
                obj.GetComponent<PrefabData>().description = itemData[1].Description;
                obj.GetComponent<PrefabData>().cost = itemData[1].cost;
                obj.GetComponent<PrefabData>().artWork = itemData[1].artWork;
                break;
            case 2:
                obj.GetComponent<PrefabData>().id = itemData[2].id;
                obj.GetComponent<PrefabData>().itemName = itemData[2].ItemName;
                obj.GetComponent<PrefabData>().description = itemData[2].Description;
                obj.GetComponent<PrefabData>().cost = itemData[2].cost;
                obj.GetComponent<PrefabData>().artWork = itemData[2].artWork;
                break;
            case 3:
                obj.GetComponent<PrefabData>().id = itemData[3].id;
                obj.GetComponent<PrefabData>().itemName = itemData[3].ItemName;
                obj.GetComponent<PrefabData>().description = itemData[3].Description;
                obj.GetComponent<PrefabData>().cost = itemData[3].cost;
                obj.GetComponent<PrefabData>().artWork = itemData[3].artWork;
                break;
            case 4:
                obj.GetComponent<PrefabData>().id = itemData[4].id;
                obj.GetComponent<PrefabData>().itemName = itemData[4].ItemName;
                obj.GetComponent<PrefabData>().description = itemData[4].Description;
                obj.GetComponent<PrefabData>().cost = itemData[4].cost;
                obj.GetComponent<PrefabData>().artWork = itemData[4].artWork;
                break;
            case 5:
                obj.GetComponent<PrefabData>().id = itemData[5].id;
                obj.GetComponent<PrefabData>().itemName = itemData[5].ItemName;
                obj.GetComponent<PrefabData>().description = itemData[5].Description;
                obj.GetComponent<PrefabData>().cost = itemData[5].cost;
                obj.GetComponent<PrefabData>().artWork = itemData[5].artWork;
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
        print("open");
        //activating and disable store when clicking Q
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

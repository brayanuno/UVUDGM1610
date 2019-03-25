using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IDropHandler
{
    public static Slot instance;
    private ArrayList CurrentItems = new ArrayList();  //store GameObjects to delete or update

    private void Start()
    {
        instance = this;
    }

    //getting the item of a child
    public GameObject item {
        get
        {
            if(transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject; //return the item children
            }
            return null;
        }
    }

    

    //adding an item in an empty slot
    public void AddItem(GameObject prefab)
    {
        Instantiate(prefab, transform);
        CurrentItems.Add(prefab);  //adding the prefab to store in the array
        prefab.GetComponent<Image>().sprite = prefab.GetComponent<PrefabData>().artWork;
       
    }

    public void OnDrop(PointerEventData eventData)
    {
       //if we dont have an item in the slot 2 items can be in the same spot
       if(!item)
       {
            DragHandler.itemBeingDragged.transform.SetParent(transform);
       }
    }
}

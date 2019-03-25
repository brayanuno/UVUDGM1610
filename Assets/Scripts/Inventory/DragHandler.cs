using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    Transform startParent;
    private Transform canvas;

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject; //this gameobject
        startPosition = transform.position;
        startParent = transform.parent;
        //setting the parent as inventory when grabbing the item
         canvas = GameObject.FindGameObjectWithTag("Inventory").transform;
        transform.parent = canvas;

        GetComponent<CanvasGroup>().blocksRaycasts = false; 
    }

    public void OnDrag(PointerEventData eventData)
    {
       
        Vector3 screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        screenPoint.z = 90f;
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint); //update the mouse and item position 

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null; //when end the drag set gameobject null
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent == canvas)
        {
            transform.position = startPosition;
            transform.parent = startParent;
        }
       
    }

}

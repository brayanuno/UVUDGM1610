using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ProfileImage : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Sprite[] imagesChoices;
    [SerializeField] private GameObject selectImage;
    [SerializeField] private GameObject Selections;
    [SerializeField] private GameObject panel;
    private GameObject lastSelected;
    void Awake ()
    {
        int rand = Random.Range(0, imagesChoices.Length);
        ImageChange(rand);
        panel.SetActive(false);
    }

    void Update()
    {

    }

    //getting the all the childs of the parent selections
    public List<GameObject> ChildImages
    {
        get {
            List<GameObject> objs = new List<GameObject>();
            foreach (Transform childimages in Selections.transform)
            {
                objs.Add(childimages.gameObject);
            }
            return objs;
        }
    }
    //when player click the image change sprites 
    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if(eventData.pointerEnter.name == selectImage.transform.name)
        {   
            panel.SetActive(true);
        }

        if (eventData.pointerEnter.name == ChildImages[0].transform.name)
        {
            RemoveLastSelected();
            ImageChange(0);
        }
        else if(eventData.pointerEnter.name == ChildImages[1].transform.name)
        {
            RemoveLastSelected();
            ImageChange(1);
        }
        else if (eventData.pointerEnter.name == ChildImages[2].transform.name)
        {
            RemoveLastSelected();
            ImageChange(2);
        }
        else if (eventData.pointerEnter.name == ChildImages[3].transform.name)
        {
            RemoveLastSelected();
            ImageChange(3);
        }
        else if (eventData.pointerEnter.name == ChildImages[4].transform.name)
        {
            RemoveLastSelected();
            ImageChange(4);
        }
        else if (eventData.pointerEnter.name == ChildImages[5].transform.name)
        {
            RemoveLastSelected();
            ImageChange(5);
        }
    }
    public void Exit()
    {
        panel.SetActive(false);
    }
    //save last selected image to remove later;
    private void RemoveLastSelected()
    {
            lastSelected.transform.GetChild(0).gameObject.SetActive(false);
    }

    //image to change the child images
    private void ImageChange(int index)
    {
        //List<GameObject> Objects
        ChildImages[index].transform.GetChild(0).gameObject.SetActive(true); //activating the arrow
        selectImage.GetComponent<Image>().sprite = imagesChoices[index]; //update sprite
        lastSelected = ChildImages[index]; //stores the last selected
    }

    private void SelectState() { 
        //if (ChildImages[0] == )
    }

}

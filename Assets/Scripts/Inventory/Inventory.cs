using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour , IHasChanged, IPointerClickHandler
{
    public static Inventory instance;
    public List<GameObject> currentItems = new List<GameObject>(); //store item GameObjects to delete or update later
    [SerializeField]Transform slots; //slot up
    [SerializeField]Transform slotsDown; //Slot down
    [SerializeField] GameObject changeUsername;
    [SerializeField] InputField username;
    [SerializeField] Button usernameButton;

    private int maxHealth;
    private int oldMaxHealth;
    private float maxSpeed;
    private float oldMaxSpeeed;
    private int maxDamage;
    private int oldMaxDamage;
    private float maxJump;
    private float oldMaxJump;

    private bool isOpen;

    private int healthIncrease; 
    private float speedIncrease;
    private int damageIncrease;
    private float jumpIncrease;

    private bool once = false;

    private void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
        changeUsername.SetActive(false);
    }
    void Update()
    {
        if (username.text == "")
        {
            usernameButton.interactable = false;
        } else { usernameButton.interactable = true; }

    }

    //check if new objects are being in the correct place to increase the player stats or not
    public void HasChanged() {
        if (transform.childCount > 0) 
            //give buff to the player when item is in the slot
            foreach (Transform SlotsTransform in slots)
            {
                GameObject item = SlotsTransform.GetComponent<Slot>().item;
                if (item)
                    //activate fisrt skill maxHitPoint (item id = 0)
                    if (item.GetComponent<PrefabData>().id == 0)
                    {
                        healthIncrease = 50;
                        maxHealth = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>().maxHitpoint + healthIncrease;
                        oldMaxHealth = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>().maxHitpoint;
                        GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>().maxHitpoint = maxHealth;
                        maxHealth = 0;
                    }
                    //activate second skill SpeedIncrease (item id = 1)
                    else if (item.GetComponent<PrefabData>().id == 1)
                    {
                        maxSpeed = 2;
                        maxSpeed = PlayerManager.instance.player.GetComponent<PlayerAnimal>().playerSpeed + speedIncrease;
                        oldMaxSpeeed = PlayerManager.instance.player.GetComponent<PlayerAnimal>().playerSpeed;
                        PlayerManager.instance.player.GetComponent<PlayerAnimal>().playerSpeed = maxSpeed;
                        maxSpeed = 0;
                    }
                    //activate third skill SpeedIncrease (item id = 0)
                    else if (item.GetComponent<PrefabData>().id == 2)
                    {
                        damageIncrease = 3;
                        maxDamage = PlayerManager.instance.player.GetComponent<PlayerBehaviour>().playerDamage + damageIncrease;
                        oldMaxDamage = PlayerManager.instance.player.GetComponent<PlayerBehaviour>().playerDamage;
                        PlayerManager.instance.player.GetComponent<PlayerBehaviour>().playerDamage = maxDamage;
                        maxDamage = 0;
                    }
                    else if (item.GetComponent<PrefabData>().id == 3)
                    {
                       
                    }
                    //activate third skill SpeedIncrease (item id = 5)
                    else if (item.GetComponent<PrefabData>().id == 5)
                    {
                        jumpIncrease = 1f;
                        maxJump = PlayerManager.instance.player.GetComponent<PlayerAnimal>().jumpHeight + jumpIncrease;
                        oldMaxJump = PlayerManager.instance.player.GetComponent<PlayerAnimal>().jumpHeight;
                        PlayerManager.instance.player.GetComponent<PlayerAnimal>().jumpHeight = maxJump;
                        maxJump = 0;
                    }
            }
            //reset the item to dont give buff in the player if the item is in the slotDown
            foreach (Transform SlotsTransformDown in slotsDown)
            {
                GameObject itemDown = SlotsTransformDown.GetComponent<Slot>().item;
                if (itemDown)
                    if (itemDown.GetComponent<PrefabData>().id == 0)
                    {
                        GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>().maxHitpoint = oldMaxHealth;
                    }

                    else if(itemDown.GetComponent<PrefabData>().id == 1)
                    {
                        PlayerManager.instance.player.GetComponent<PlayerAnimal>().playerSpeed = oldMaxSpeeed;
                    }

                    else if (itemDown.GetComponent<PrefabData>().id == 2)
                    {
                        PlayerManager.instance.player.GetComponent<PlayerBehaviour>().playerDamage = oldMaxDamage;
                    }
                    
                    else if (itemDown.GetComponent<PrefabData>().id == 5)
                    {
                        PlayerManager.instance.player.GetComponent<PlayerAnimal>().jumpHeight = oldMaxJump;
                    }
                    
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;
        
        //this foreach only work for the slot
        foreach (Transform SlotsTransform in transform.GetChild(0))
        {
            GameObject item = SlotsTransform.GetComponentInChildren<Slot>().item;
            if (item)
            {
                if (clickCount == 2 && item.GetComponent<PrefabData>().id == 3)
                {
                    changeUsername.SetActive(true);
                }
                if (clickCount == 2 && item.GetComponent<PrefabData>().id == 4)
                {
                    KillOne();
                }
            } 
        }
        //this foreach only work for the Bottomslot
        foreach (Transform SlotsTransform in transform.GetChild(1))
        {
            GameObject item = SlotsTransform.GetComponentInChildren<Slot>().item;
            if (item)
            {  
                if (clickCount == 2 && item.GetComponent<PrefabData>().id == 3)
                {
                    changeUsername.SetActive(true);
                }
                if (clickCount == 2 && item.GetComponent<PrefabData>().id == 4)
                {
                    KillOne();
                }
            }
        }
    }

    //getting the specific id with specific object with id
    public GameObject FindObjectByID(int ID)
    {
        GameObject result = null;
        for (int i = 0; i < currentItems.Count; i++)
        {
            if (currentItems[i].GetComponent<PrefabData>().id == 3)
            {
                print("got it");
                result = currentItems[i];
                break;
            }
        }
        return result;
    }
    
    public void AddCurrentItem(GameObject obj)
    {
        currentItems.Add(obj);
        print("added");
    }

    public void UsernameExit()
    {
        Destroy(FindObjectByID(3));
        PlayerInfo.instance.username = username.text;
        changeUsername.SetActive(false);
        print("working");
        print(FindObjectByID(3));
    }

    private void KillOne()
    {
        Destroy(PlayerManager.instance.player.GetComponent<PlayerBehaviour>().ClosestEnemyObject());
    }

    public void Exit()
    {
        gameObject.SetActive(false);
    } 

    public void OpenInventory()
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

    }
}

namespace UnityEngine.EventSystems {
    public interface IHasChanged : IEventSystemHandler { void HasChanged(); }

}



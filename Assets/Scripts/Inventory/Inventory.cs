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
    private bool isOpen;

    private int maxHealth;
    private int oldMaxHealth;
    private float maxSpeed;
    private float oldMaxSpeeed;
    private int maxDamage;
    private int oldMaxDamage;
    private float maxJump;
    private float oldMaxJump;

    private bool healthinSlot;
    private bool damageinSlot;
    private bool speedinSlot;
    private bool jumpinSlot;

    private bool once = false;

    private void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
        changeUsername.SetActive(false);
        healthinSlot = false;
        damageinSlot = false;
        speedinSlot = false;
        jumpinSlot = false;
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
        if (slots.transform.childCount > 0)
        {
            //give buff to the player when item is in the slot
            foreach (Transform SlotsTransform in slots)
            {
                GameObject item = SlotsTransform.GetComponent<Slot>().item;
                if (item)
                    //activate fisrt skill maxHitPoint (item id = 0)
                    if (item.GetComponent<PrefabData>().id == 0)
                    {
                        if(!healthinSlot)
                        {
                            int healthIncrease = 50;
                            maxHealth = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>().maxHitpoint + healthIncrease;
                            oldMaxHealth = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>().maxHitpoint;
                            GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>().maxHitpoint = maxHealth;
                            maxHealth = 0;
                            healthinSlot = true;
                        }
                    }
                    //activate second skill SpeedIncrease (item id = 1)
                    else if (item.GetComponent<PrefabData>().id == 1)
                    {
                        if (!speedinSlot)
                        {
                            int speedIncrease = 2;
                            maxSpeed = PlayerManager.instance.player.GetComponent<PlayerAnimal>().playerSpeed + speedIncrease;
                            oldMaxSpeeed = PlayerManager.instance.player.GetComponent<PlayerAnimal>().playerSpeed;
                            PlayerManager.instance.player.GetComponent<PlayerAnimal>().playerSpeed = maxSpeed;
                            maxSpeed = 0;
                            speedinSlot = true;
                        }
                    }
                    //activate third skill SpeedIncrease (item id = 0)
                    else if (item.GetComponent<PrefabData>().id == 2)
                    {
                        if(!damageinSlot)
                        {
                            int damageIncrease = 3;
                            maxDamage = PlayerManager.instance.player.GetComponent<PlayerBehaviour>().playerDamage + damageIncrease;
                            oldMaxDamage = PlayerManager.instance.player.GetComponent<PlayerBehaviour>().playerDamage;
                            PlayerManager.instance.player.GetComponent<PlayerBehaviour>().playerDamage = maxDamage;
                            maxDamage = 0;
                            damageinSlot = true;
                        }
                    }
                    //activate third skill SpeedIncrease (item id = 5)
                    else if (item.GetComponent<PrefabData>().id == 5)
                    {
                        if (!damageinSlot)
                        {
                            float jumpIncrease = 1f;
                            maxJump = PlayerManager.instance.player.GetComponent<PlayerAnimal>().jumpHeight + jumpIncrease;
                            oldMaxJump = PlayerManager.instance.player.GetComponent<PlayerAnimal>().jumpHeight;
                            PlayerManager.instance.player.GetComponent<PlayerAnimal>().jumpHeight = maxJump;
                            maxJump = 0;
                            jumpinSlot = true;
                        }
                    }
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
                    healthinSlot = false;
                }

                else if (itemDown.GetComponent<PrefabData>().id == 1)
                {
                    PlayerManager.instance.player.GetComponent<PlayerAnimal>().playerSpeed = oldMaxSpeeed;
                    speedinSlot = false;
                }

                else if (itemDown.GetComponent<PrefabData>().id == 2)
                {
                    PlayerManager.instance.player.GetComponent<PlayerBehaviour>().playerDamage = oldMaxDamage;
                    damageinSlot = false;
                }

                else if (itemDown.GetComponent<PrefabData>().id == 5)
                {
                    PlayerManager.instance.player.GetComponent<PlayerAnimal>().jumpHeight = oldMaxJump;
                    jumpinSlot = false;
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
            if (currentItems[i].GetComponent<PrefabData>().id == ID)
            {
                result = currentItems[i];
                break;
            }
        }
        return result;
    }
    
    public void AddCurrentItem(GameObject obj)
    {
        currentItems.Add(obj);
    }

    public void UsernameExit()
    {
        Destroy(FindObjectByID(3));
        PlayerInfo.instance.username = username.text;
        changeUsername.SetActive(false);
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

        //if (Store.instance.GetComponent<Store>().gameObject.activeInHierarchy)
        //{
           // Store.instance.GetComponent<Store>().Exit();
        //}

    }
}

namespace UnityEngine.EventSystems {
    public interface IHasChanged : IEventSystemHandler { void HasChanged(); }

}



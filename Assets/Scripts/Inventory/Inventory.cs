using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]Transform slots; //slot up
    private float playerCurrentSpeed; //storage the playerCurrentSpeed 
    private int currentDamage;
    private float currentJumpHeight;
    
    private bool isOpen;

    private void Start()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        HasChanged();
    }

    //check if new objects are being place to increase the player player stats
    public void HasChanged()
    {
        if (transform.childCount > 0)
            foreach (Transform SlotsTransform in slots)
            {
                GameObject item = SlotsTransform.GetComponent<Slot>().item;
                if (item)
                {
                    //activate new first skill
                    if (item.GetComponent<PrefabData>().id == 0) {
                        GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>().maxHitpoint += 50;
                        print("this is the first skills");
                    } else {
                        GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>().maxHitpoint -= 50;
                    }

                    //activate the seconds skill
                    if (item.GetComponent<PrefabData>().id == 1) {
                        playerCurrentSpeed = PlayerManager.instance.player.GetComponent<PlayerAnimal>().playerSpeed;
                        PlayerManager.instance.player.GetComponent<PlayerAnimal>().playerSpeed += 1;
                        print("this is the seconds skills");
                    } else
                    {
                        print("second Skill unavailable");
                        PlayerManager.instance.player.GetComponent<PlayerAnimal>().playerSpeed = playerCurrentSpeed;
                    }
                    //activate the third skill
                    if (item.GetComponent<PrefabData>().id == 2)
                    {
                        currentDamage = PlayerManager.instance.player.GetComponent<PlayerBehaviour>().playerDamage;
                        PlayerManager.instance.player.GetComponent<PlayerBehaviour>().playerDamage += 3;
                    } else {
                        PlayerManager.instance.player.GetComponent<PlayerBehaviour>().playerDamage = currentDamage;
                        print("third Skill unavailable");
                    }

                    //activate the fourth skill
                    if (item.GetComponent<PrefabData>().id == 3)
                    {
                        //this is the section of changing name 
                    }

                    //activate the fifth skill
                    else if(item.GetComponent<PrefabData>().id == 4)
                    {
                        //Destroy the closest enemy
                        Destroy(PlayerManager.instance.player.GetComponent<PlayerBehaviour>().ClosestEnemyObject());
                        print("fifth Skill activate");

                    }

                    //activate the sixth skill
                    else if (item.GetComponent<PrefabData>().id == 5)
                    {
                        //Destroy the closest enemy
                        currentJumpHeight = PlayerManager.instance.player.GetComponent<PlayerAnimal>().jumpHeight;
                        PlayerManager.instance.player.GetComponent<PlayerAnimal>().jumpHeight += 0.5f;
                        print("sixth Skill activated");

                    } else {
                        PlayerManager.instance.player.GetComponent<PlayerAnimal>().jumpHeight = currentJumpHeight;
                        print("sixth Skill unavailable");
                    }
                }
            }
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




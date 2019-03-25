using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    //Powers fill up
    public Transform[] LoadingBar;
    public GameObject[] imagesOnReady;
    //public Transform TextLoading;

    //saving the information of the current time of each power
    private float currentFirstPower;
    private float currentSecondPower;
    private float currentThirdPower;

    //store the ratio of the delay image
    private float delayFirstPower;
    private float delayThirdPower;

    //delay conditions to activate the delay fill image amount
    private bool firstPowerActivated;
    private bool thirdPowerActivated;

    //time duration of first and third skills 
    private float firstSkillDuration = 4f;
    private float thirdSillDuration = 6f;

    //speed of the power
    private int[] speedPowers = { 10,5,15};
    private bool[] powerAvailable = new bool[3];

    private void Start()
    {
        currentFirstPower = 0;
        currentSecondPower = 0;
        currentThirdPower = 0;

        delayFirstPower = 0;
        
        for(int i = 0;i < powerAvailable.Length; i++)
        {
            powerAvailable[i] = false;
        }
    }
    void Update()
    {
        //power is loading
        if (currentFirstPower < 100) {
            currentFirstPower += speedPowers[0] * Time.deltaTime;
            powerAvailable[0] = false; //cannot use power even if you press the keycode
            imagesOnReady[0].SetActive(false);
        } else
        {
            //power is done  to user
            powerAvailable[0] = true;
                imagesOnReady[0].SetActive(true);
        }

        //power is loading
        if (currentSecondPower < 100) {
            currentSecondPower += speedPowers[1] * Time.deltaTime;
            powerAvailable[1] = false; //cannot use power even if you press the keycode
            imagesOnReady[1].SetActive(false);
        } else
        {
            //power is done  to user
            powerAvailable[1] = true;
            imagesOnReady[1].SetActive(true);
        }

        //power is loading
        if (currentThirdPower < 100)
        {
            currentThirdPower += speedPowers[2] * Time.deltaTime;
            powerAvailable[2] = false; //cannot use power even if you press the keycode
            imagesOnReady[2].SetActive(false);
        }
        else
        {
            //power is done  to user
            powerAvailable[2] = true;
            imagesOnReady[2].SetActive(true);
        }

        LoadingBar[0].GetComponent<Image>().fillAmount = currentFirstPower / 100;
        LoadingBar[1].GetComponent<Image>().fillAmount = currentSecondPower/ 100;
        LoadingBar[2].GetComponent<Image>().fillAmount = currentThirdPower / 100;

        //activating the delay of the powerups
        DelayPowerUps();
    }
        
    public void PowerUp(int index)
    {
        //first power add player speed during 4 seconds
        if (index == 0 && powerAvailable[0])
        {
            float PlayerSpeed = PlayerManager.instance.player.GetComponent<PlayerAnimal>().playerSpeed; //saving the previous info of our player
            PlayerManager.instance.player.GetComponent<PlayerAnimal>().playerSpeed += 3f;
            PanelControls.instance.ActivatePanel(PanelControls.instance.AlertSkills[0], "+4 Speed"); //activating the panel in the scene
            firstPowerActivated = true;
            StartCoroutine(PowerTimer(0, PlayerSpeed, 4));
        } 
        
        //seconds Power add more health to our player no required any delay system
        if (index == 1 && powerAvailable[1])
        {
            GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>().hitpoint += 10;  //adding health to our Player
            PanelControls.instance.SpecialPanel(PanelControls.instance.AlertSkills[1], "+25 HitPoint",1); //activating the panel for 1 seconds in the scene
            powerAvailable[1] = false;
            currentSecondPower = 0; //reseting
        }
        //thirdPower addd more damage to our player
        if (index == 2 && powerAvailable[2])
        {
            float PlayerDamage = PlayerManager.instance.player.GetComponent<PlayerBehaviour>().playerDamage;  //saving the previous info of our player
            PlayerManager.instance.player.GetComponent<PlayerBehaviour>().playerDamage += 5;
            PanelControls.instance.ActivatePanel(PanelControls.instance.AlertSkills[2], "+6 Damage"); //activating the panel in the scene
            thirdPowerActivated = true;
            StartCoroutine(PowerTimer(1, PlayerDamage, 6));
        }
    }

    //increase the buffs in everySkill by seconds
    public IEnumerator PowerTimer(int index, float behavior,int seconds)
    {   if (index == 0)
        {  
            yield return new WaitForSeconds(seconds);
            PanelControls.instance.DesactivatePanel(PanelControls.instance.AlertSkills[0]); //Desactivating the panels
            PlayerManager.instance.player.GetComponent<PlayerAnimal>().playerSpeed = behavior;
            firstPowerActivated = false;
            powerAvailable[0] = false;
            currentFirstPower = 0; //reseting to load again the skill
        }

        if(index == 1)
        {
            yield return new WaitForSeconds(seconds);
            PanelControls.instance.DesactivatePanel(PanelControls.instance.AlertSkills[2]); //Desactivating the panels
            PlayerManager.instance.player.GetComponent<PlayerBehaviour>().playerDamage = (int)behavior;
            powerAvailable[2] = false;
            currentThirdPower = 0; //reseting to load again the skill
        }
    }

    //activate a loading bar in delay 
    private void DelayPowerUps()
    {
        if (firstPowerActivated)
        {
            GameObject.Find("FirstPower").transform.Find("Delay").gameObject.SetActive(true);
            delayFirstPower += 100/firstSkillDuration * Time.deltaTime; // 100/ duration of the first skill
            GameObject.Find("FirstPower").transform.Find("Delay").GetComponent<Image>().fillAmount = delayFirstPower / 100;
        }
        else
        {
            GameObject.Find("FirstPower").transform.Find("Delay").gameObject.SetActive(false);
            delayFirstPower = 0;
        }

        if (thirdPowerActivated)
        {
            GameObject.Find("ThirdPower").transform.Find("Delay").gameObject.SetActive(true);
            delayThirdPower += 100/thirdSillDuration * Time.deltaTime; // 100/ duration of the third skill
            GameObject.Find("ThirdPower").transform.Find("Delay").GetComponent<Image>().fillAmount = delayThirdPower / 100;
        }
        else
        {
            GameObject.Find("ThirdPower").transform.Find("Delay").gameObject.SetActive(false);
            delayThirdPower = 0;
        }
    }


}

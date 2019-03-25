using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelControls : MonoBehaviour
{
    public GameObject AlertPanel;
    public GameObject[] AlertSkills;
    public static PanelControls instance;

    void Awake()
    {
        AlertPanel.SetActive(false);
        for(int i = 0; i < AlertSkills.Length;i++)
        {
            AlertSkills[i].SetActive(false);
        }
        instance = this;
    }

    public void ActivatePanel(GameObject obj,string text)
    {
        obj.transform.Find("Text").GetComponent<Text>().text = text;
        obj.SetActive(true);

    }

    public void DesactivatePanel(GameObject obj)
    {
        obj.SetActive(false);
    }


    public void SpecialPanel(GameObject obj, string text,int duration)
    {
        obj.transform.Find("Text").GetComponent<Text>().text = text;
        obj.SetActive(true);
        StartCoroutine(DisplayPanelSeconds(1));
        obj.SetActive(false);

    }

    //wait for any seconds
    public IEnumerator DisplayPanelSeconds(int seconds)
    {

        yield return new WaitForSeconds(seconds);
    }
}

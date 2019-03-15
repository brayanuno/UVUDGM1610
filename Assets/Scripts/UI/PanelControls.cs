using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelControls : MonoBehaviour
{
    public GameObject AlertPanel;
    public static PanelControls instance;

    void Awake()
    {
        AlertPanel.SetActive(false);
        instance = this;
    }

    public void ActivatePanel(GameObject obj,string text)
    {
        obj.transform.Find("Text").GetComponent<Text>().text = text + " is close";
        obj.SetActive(true);

    }

    public void DesactivatePanel(GameObject obj)
    {
        obj.SetActive(false);
    }
}

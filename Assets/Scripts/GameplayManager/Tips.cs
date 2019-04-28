using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tips : MonoBehaviour
{
    private int tipsNum;
    [SerializeField] private Text tip;
    private string[] tipsText = new string[3];
    // Start is called before the first frame update
    void Start()
    {
        tipsText[0] = "Buy Items in the store and equip in the inventory.";
        tipsText[1] = "You can change your avatar image clicking the image";
        tipsText[2] = "Press z or x or c to use different skills";
        StartCoroutine(WaitAndPrint());
        print("tip");
    }

    // Update is called once per frame

    private IEnumerator WaitAndPrint()
    {
        print("tip");
        tip.text = "Tip:" + tipsText[0];
        yield return new WaitForSeconds(2);
        tip.text = "Tip:" + tipsText[1];
        yield return new WaitForSeconds(2);
        tip.text = "Tip:" + tipsText[2];
        yield return new WaitForSeconds(2);
        StartCoroutine(WaitAndPrint());
    }
}

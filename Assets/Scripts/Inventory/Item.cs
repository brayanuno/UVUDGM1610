using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem" , menuName = "Item")]
public class Item : ScriptableObject
{
    public int id;
    public string ItemName;
    public string Description;
    public int cost;
    public Sprite artWork;

}

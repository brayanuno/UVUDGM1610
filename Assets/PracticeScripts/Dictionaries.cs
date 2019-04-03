using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Dictionary Exercises
/// </summary>
public class Dictionaries : MonoBehaviour
{
    public Hashtable personalInfor = new Hashtable();
    public Hashtable DamageWeapon = new Hashtable();
    public Hashtable Enemy = new Hashtable();
    // Start is called before the first frame update
    void Start()
    {
        personalInfor.Add("firstName", "Greg");
        personalInfor.Add("lastName", "fernandez");
        personalInfor.Add("gender", "male");
        personalInfor.Add("alive", true);
        personalInfor.Add("age", 19);

        DamageWeapon.Add("name", "Arrow");
        DamageWeapon.Add("bullet", "Gold");
        DamageWeapon.Add("basecolor", "Red");
        DamageWeapon.Add("range", 10);
        DamageWeapon.Add("damage", 10);

        Enemy.Add("Name", "Primo");
        Enemy.Add("Class", "Warrior");
        Enemy.Add("Damage", 10);
        Enemy.Add("Respawn", false);
        Enemy.Add("age", 10);

       foreach (DictionaryEntry dic in Enemy)
        {
            Debug.Log(dic.Key + "// " +  dic.Value);
        }
        foreach (DictionaryEntry dic in personalInfor)
        {
            Debug.Log(dic.Key + "// " + dic.Value);
        }
        foreach (DictionaryEntry dic in DamageWeapon)
        {
            Debug.Log(dic.Key + "// " + dic.Value);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

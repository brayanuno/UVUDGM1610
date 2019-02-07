using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroLobby : MonoBehaviour
{
    //public static HeroLobby heroLobby;
    [SerializeField]
    private GameObject heroLobby;
    [SerializeField]
    private HeroeList heroeList;
    
    public Text health;
    public Text name;
    public Text attack;
    public Text speed;
    public Text armor;
    public Text stars;
    public Text role;
    public Text primarySkill;
    public Text passiveSkill;
    public Text secondaryPassiveSkill;
    public Text lastPassiveSkill;

    private int goldAmount;
    private int soulShardAmount;

    [SerializeField]
    private Text gold;
    [SerializeField]
    private Text soulShard;


    // Start is called before the first frame update
    void Start()
    {
        name.text = "not working";
    }
    //PASSING the argument and setting the information in the heroLobby
    public void heroInfo(int id, string name, int stars, int health, 
        int attack, int armor, int speed, string role, string primarySkill, 
        string passiveSkill, string secondaryPassiveSkill, string lastPassiveSkill)
    {
        this.name.text = name;
        this.stars.text = stars.ToString();
        this.health.text = health.ToString();
        this.attack.text = attack.ToString();
        this.armor.text = armor.ToString();
        this.speed.text = speed.ToString();
        this.role.text = role;
        this.role.text = role;
        this.primarySkill.text = primarySkill;
        this.passiveSkill.text = passiveSkill;
        this.secondaryPassiveSkill.text = secondaryPassiveSkill;
        this.lastPassiveSkill.text = lastPassiveSkill;
    }

    public void ButtonExit()
    {
        heroLobby.SetActive(false);
    }

    public void LevelUp()
    {

    }


}

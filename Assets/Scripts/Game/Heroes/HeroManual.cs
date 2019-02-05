using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManual : MonoBehaviour
{   //private variables
    private int heroesTotal;
    private int[] heroesId;
    private string name;
    private int stars;
    private int health;
    private int attack;
    private int armor;
    private int speed;

    private string primarySkill;
    private string passiveSkill;
    private string secondaryPassiveSkill;
    private string lastPassiveSkill;

    private string role;
    // public Text Object
    
    // Settin new heroes in the first frame
    // Start is called before the first frame update
    void Start()
    {
        heroesTotal = 45;
        HeroesId();

    }

    public HeroManual(string name, int stars, int health, int attack, int armor, int speed, string role , string primarySkill, string passiveSkill , string secondaryPassiveSkill , string lastPassiveSkill)
    {
        
        this.name = name;
        this.stars = stars;
        this.health = health;
        this.attack = attack;
        this.armor = armor;
        this.speed = speed;
        this.role = role;
        this.primarySkill = primarySkill;
        this.passiveSkill = passiveSkill;
        this.secondaryPassiveSkill = secondaryPassiveSkill;
        this.lastPassiveSkill = passiveSkill;

    }




    // Start is called before the first frame update
    

    private void HeroesId()
    {
        //setting the Id for each character 
        for (int i = 0; i < heroesTotal; i++)
        {
            heroesId[i] = i + 1;
            HeroesStats(heroesId[i]);

        }
    }
    //setting the stats of every Heroe
    public void HeroesStats(int id )
    {
        switch(id)
        {
            case 1:
                HeroManual heroIdOne =  new HeroManual("brayan", 3, 10000, 300, 400, 300, "assasin","the enemyAttacks two Random Enemies by 230%" , "increase hp by 10% and attack by 20%","basic attack deals 145%", "every enemy died gain 20% hp");       
                break;
            case 2:
                HeroManual heroIdTwo = new HeroManual("two", 3, 10000, 300, 400, 300, "assasin",  "the enemyAttacks two Random Enemies by 230%", "increase hp by 10% and attack by 20%", "basic attack deals 145%", "every enemy died gain 20% hp");
                break;
            case 3:
                HeroManual heroIdThree  = new HeroManual("three", 3, 10000, 300, 400, 300, "assasin","the enemyAttacks two Random Enemies by 230%", "increase hp by 10% and attack by 20%", "basic attack deals 145%", "every enemy died gain 20% hp");
                break;
            case 4:
                HeroManual heroIdFourth = new HeroManual("fourth", 3, 10000, 300, 400, 300, "assasin", "the enemyAttacks two Random Enemies by 230%", "increase hp by 10% and attack by 20%", "basic attack deals 145%", "every enemy died gain 20% hp");
                break;
            case 5:
                HeroManual heroIdFive = new HeroManual("five", 3, 10000, 300, 400, 300, "assasin", "the enemyAttacks two Random Enemies by 230%", "increase hp by 10% and attack by 20%", "basic attack deals 145%", "every enemy died gain 20% hp");
                break;
            case 6:
                HeroManual heroIdSix = new HeroManual("six", 3, 10000, 300, 400, 300, "assasin", "the enemyAttacks two Random Enemies by 230%", "increase hp by 10% and attack by 20%", "basic attack deals 145%", "every enemy died gain 20% hp");
                break;
            case 7:
                HeroManual heroIdSeven = new HeroManual("seven", 3, 10000, 300, 400, 300, "assasin", "the enemyAttacks two Random Enemies by 230%", "increase hp by 10% and attack by 20%", "basic attack deals 145%", "every enemy died gain 20% hp");
                break;
            case 8:
                HeroManual heroIdEight = new HeroManual("eight", 3, 10000, 300, 400, 300, "assasin", "the enemyAttacks two Random Enemies by 230%", "increase hp by 10% and attack by 20%", "basic attack deals 145%", "every enemy died gain 20% hp");
                break;
            case 9:
                HeroManual heroIdNine = new HeroManual("nine", 3, 10000, 300, 400, 300, "assasin", "the enemyAttacks two Random Enemies by 230%", "increase hp by 10% and attack by 20%", "basic attack deals 145%", "every enemy died gain 20% hp");
                break;
            case 10:
                HeroManual heroIdTen = new HeroManual("ten", 3, 10000, 300, 400, 300, "assasin", "the enemyAttacks two Random Enemies by 230%", "increase hp by 10% and attack by 20%", "basic attack deals 145%", "every enemy died gain 20% hp");
                break;
        }
    }

   



}

    


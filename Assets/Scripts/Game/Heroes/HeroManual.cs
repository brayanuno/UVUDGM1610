using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroManual : MonoBehaviour
   
{   //private variables
    public HeroeList heroeList;
    public HeroManual heroManual;

    public int heroesTotal;
    public int id;
    public string name;
    public int stars;
    public int health;
    public int attack;
    public int armor;
    public int speed;

    public string primarySkill;
    public string passiveSkill;
    public string secondaryPassiveSkill;
    public string lastPassiveSkill;

    public string role;

   

    public HeroManual(int id, string name, int stars, int health, int attack, int armor, int speed, string role, string primarySkill, string passiveSkill, string secondaryPassiveSkill, string lastPassiveSkill)
    {
        this.id = id;
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
     void Start()
    {
      
    }


    // Settin new heroes in the first frame
    // Start is called before the first frame update
    public void herobyId(int id) 
    {
        switch(id)
        {
            case 1:
                heroManual = new HeroManual(1, "brayan", 3, 10000, 100, 400, 300, "assasin", "the enemyAttacks two Random Enemies by 230%", "increase hp by 10% and attack by 20%", "basic attack deals 145%", "every enemy died gain 20% hp");
                break;
            case 2:
                heroManual = new HeroManual(2, "brayan", 3, 30000, 200, 400, 300, "assasin", "the enemyAttacks two Random Enemies by 230%", "increase hp by 10% and attack by 20%", "basic attack deals 145%", "every enemy died gain 20% hp");
                break;
            case 3:
                heroManual = new HeroManual(1, "brayan",4, 10300, 300, 400, 300, "assasin", "the enemyAttacks two Random Enemies by 230%", "increase hp by 10% and attack by 20%", "basic attack deals 145%", "every enemy died gain 20% hp");
                break;
            case 4:
                heroManual = new HeroManual(4, "fourth", 4, 14000, 400, 400, 300, "assasin", "the enemyAttacks two Random Enemies by 230%", "increase hp by 10% and attack by 20%", "basic attack deals 145%", "every enemy died gain 20% hp");
                break;
            case 5:
                heroManual = new HeroManual(5, "five", 5, 10000, 500, 400, 300, "assasin", "the enemyAttacks two Random Enemies by 230%", "increase hp by 10% and attack by 20%", "basic attack deals 145%", "every enemy died gain 20% hp");
                break;
            case 6:
                heroManual = new HeroManual(6, "six", 5, 23000, 600, 400, 300, "assasin", "the enemyAttacks two Random Enemies by 230%", "increase hp by 10% and attack by 20%", "basic attack deals 145%", "every enemy died gain 20% hp");
                break;
            case 7:
                heroManual = new HeroManual(7, "seven", 6, 89000,700, 400, 300, "assasin", "the enemyAttacks two Random Enemies by 230%", "increase hp by 10% and attack by 20%", "basic attack deals 145%", "every enemy died gain 20% hp");
                break;
            case 8:
                heroManual = new HeroManual(8, "eight", 6, 1030000, 800, 400, 300, "assasin", "the enemyAttacks two Random Enemies by 230%", "increase hp by 10% and attack by 20%", "basic attack deals 145%", "every enemy died gain 20% hp");
                break;
            case 9:
                heroManual = new HeroManual(9, "nine", 7, 102000, 900, 400, 300, "assasin", "the enemyAttacks two Random Enemies by 230%", "increase hp by 10% and attack by 20%", "basic attack deals 145%", "every enemy died gain 20% hp");
                break;
            case 10:
                heroManual = new HeroManual(10, "iMTHEnUMBER10", 7, 231000, 1000, 400, 300, "assasin", "the enemyAttacks two Random Enemies by 230%", "increase hp by 10% and attack by 20%", "basic attack deals 145%", "every enemy died gain 20% hp");
                break;
        }
    }
 

    public void HeroManualList()
    {

    }
}
    

    


    // Start is called before the first frame update
    


    
        //setting the Id for each character 
        //for (int i = 0; i < heroesTotal; i++)
        //{
            //heroesId[i] = i + 1;
            //HeroesStats(heroesId[i]);

        //}
    
    //setting the stats of every Heroe
   
   





    


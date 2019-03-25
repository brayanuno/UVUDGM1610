using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// Onloading new scene gets all the information from the new character
/// </summary>
public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo instance;
    private CreateClassSystem createClassSystem;
    //spawning the player
    [SerializeField] private GameObject[] characterPrefabs;
    [SerializeField] private Transform positionPlayer;

    public int id;
    public string username;
    public int hitPoint;
    public float radarPlayer;
    public int playerDamage;
    public float speedPlayer;
    public float jumpHeight;
    public bool restartStats; //restart stats condition

    public GameObject displayingInfo;
    //saving info of the player to later call whenever you need
    private void Awake()
    {
        instance = this;
        createClassSystem = GameObject.Find("CharacterManager").GetComponent<CreateClassSystem>();    
        this.id = createClassSystem.newCharacter.id;
        this.username = createClassSystem.newCharacter.userName;
        this.hitPoint = createClassSystem.newCharacter.hitPoint;
        this.radarPlayer = createClassSystem.newCharacter.radarPlayer;
        this.playerDamage = createClassSystem.newCharacter.playerDamage;
        this.speedPlayer = createClassSystem.newCharacter.speedPlayer;
        this.jumpHeight = createClassSystem.newCharacter.jumpHeight;
        restartStats = true;
        StartCoroutine(WaitForIntro(2f));
    }

    //creating a prefab accoding the id of the player
    public void CreatePrefab(int id)
    {
        switch (id)
        {
            case 0:
                Instantiate(characterPrefabs[0], positionPlayer.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(characterPrefabs[1], positionPlayer.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(characterPrefabs[2], positionPlayer.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(characterPrefabs[3], positionPlayer.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(characterPrefabs[4], positionPlayer.position, Quaternion.identity);
                break;
        }
    }
    //after a determined seconds the player is not allow to reset stats 
    public IEnumerator WaitForIntro(float waitTime)
    {
        CreatePrefab(createClassSystem.newCharacter.id);
        yield return new WaitForSeconds(waitTime);
        restartStats = false; //the stats cannot be reverted

    }


}

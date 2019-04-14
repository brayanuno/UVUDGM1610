using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private Text HP;
    [SerializeField] private Text attack;
    [SerializeField] private Text jump;
    [SerializeField] private Text speed;
    private GameObject StatsPanel;

    private void Start()
    {
        player = PlayerManager.instance.player;
        StatsPanel = transform.Find("Stats").gameObject;
    }
    private void Update()
    {
        UpdateStats();
    }

    private void UpdateStats()
    {
        HP.text = GameObject.Find("HealthBar").GetComponent<HealthBar>().hitpoint.ToString();
        attack.text = PlayerManager.instance.player.GetComponent<PlayerBehaviour>().playerDamage.ToString();
        jump.text = PlayerManager.instance.player.GetComponent<PlayerAnimal>().jumpHeight.ToString();
        speed.text = PlayerManager.instance.player.GetComponent<PlayerAnimal>().playerSpeed.ToString();
    }

    public void Open()
    {
        StatsPanel.SetActive(true);
    }

    public void Close()
    {
        StatsPanel.SetActive(false);
    }
}

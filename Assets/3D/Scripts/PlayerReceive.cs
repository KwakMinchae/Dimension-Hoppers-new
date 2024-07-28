using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerReceive : MonoBehaviour
{
    public int maxHP = 500;
    public int playerHealth; 
    public Collider PlayerCollider;

    [SerializeField] PlayerHealthbar Playerhealthbar;

    private void Awake()
    {
        Playerhealthbar = GetComponentInChildren<PlayerHealthbar>();
    }

    void Start()
    {
        PlayerCollider = GetComponent<Collider>();
        PlayerCollider.isTrigger = true;
        Playerhealthbar.UpdatePlayerHealthbar(playerHealth, maxHP);

//Playerpref for Health
        LoadHealth();
    }

    void LoadHealth()
    {
        playerHealth = PlayerPrefs.GetInt("PlayerHealth"); //default is 500. 
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad >= 29)
        {
            SaveHealth();
        }
    }

    void SaveHealth()
    {
        PlayerPrefs.SetInt("PlayerHealth", playerHealth); 
        PlayerPrefs.Save(); 
    }
// Playerpref for Health (ended)


    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Enemy") || (other.gameObject.tag == "Dragon")) //set so that player takes damage from both enemies 
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        playerHealth -= damageAmount;
        Playerhealthbar.UpdatePlayerHealthbar(playerHealth, maxHP);

        if (playerHealth<=0)
        {
           loadEnd();
        }
    }

    public void loadEnd()
    {
        SceneManager.LoadScene("GameOver");
    }

}
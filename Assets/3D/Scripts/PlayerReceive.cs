using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReceive : MonoBehaviour
{
    public int maxHP = 500;
    public int playerHealth = 500; 
    //public Animator animator;
    public Collider PlayerCollider;
    //public Rigidbody rb;

    [SerializeField] PlayerHealthbar Playerhealthbar;

    private void Awake()
    {
        Playerhealthbar = GetComponentInChildren<PlayerHealthbar>();
        int playerHealth = 500;
    }

    void start()
    {
        PlayerCollider = GetComponent<Collider>();
        PlayerCollider.isTrigger = true;
        //rb = GetComponent<Rigidbody>();
        //rb.isKinematic = true;   
        Playerhealthbar.UpdatePlayerHealthbar(playerHealth, maxHP);

//Playerpref for Health
        LoadHealth();
    }

    void LoadHealth()
    {
        playerHealth = PlayerPrefs.GetInt("PlayerHealth", 500); //default is 500. 
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
        if (other.gameObject.tag == "Enemy")
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
            Debug.Log("Player is injured");
        }
        else
        {
            Debug.Log("Player is dead");
        }
    }

}
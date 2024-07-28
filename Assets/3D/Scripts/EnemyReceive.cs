using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHP = 500;
    public int theEnemyHealth = 500;
    public Collider EnemyCollider;
    public Rigidbody rb;
    public GameObject orange;

    [SerializeField] Healthbar healthbar;

    private void Awake()
    {
        healthbar = GetComponentInChildren<Healthbar>();
    }

    void Start()
    {
        EnemyCollider = GetComponent<Collider>();
        EnemyCollider.isTrigger = true;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;   
        healthbar.UpdateHealthbar(theEnemyHealth, maxHP);

//Playerpref for theEnemyHealth
        LoadHealth(); 
    }
    
    void LoadHealth()
    {
        theEnemyHealth = PlayerPrefs.GetInt("TheEnemyHealth", 500); //default is 500. 
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
        PlayerPrefs.SetInt("TheEnemyHealth", theEnemyHealth); 
        PlayerPrefs.Save(); 
    }
//End of PlayerPref
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sword")
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        theEnemyHealth -= damageAmount;
        healthbar.UpdateHealthbar(theEnemyHealth, maxHP);

        if (theEnemyHealth<=0)
        {
            Destroy(orange);
        }
    }

}
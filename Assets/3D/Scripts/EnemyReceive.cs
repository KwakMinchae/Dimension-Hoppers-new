using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHP = 500;
    public int enemyHealth = 500;
    //public Animator animator;
    public Collider EnemyCollider;
    public Rigidbody rb;
    public GameObject orange;

    [SerializeField] Healthbar healthbar;

    private void Awake()
    {
        healthbar = GetComponentInChildren<Healthbar>();
    }

    void start()
    {
        EnemyCollider = GetComponent<Collider>();
        EnemyCollider.isTrigger = true;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;   
        healthbar.UpdateHealthbar(enemyHealth, maxHP);

//Playerpref for enemyHealth
        LoadHealth(); 
    }
    
    void LoadHealth()
    {
        enemyHealth = PlayerPrefs.GetInt("EnemyHealth", 500); //default is 500. 
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
        PlayerPrefs.SetInt("EnemyHealth", enemyHealth); 
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
        enemyHealth -= damageAmount;
        healthbar.UpdateHealthbar(enemyHealth, maxHP);

        if (enemyHealth<=0)
        {
            //animator.SetTrigger("Dead 0");
            Destroy(orange);
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dragon : MonoBehaviour
{
    public int maxHP = 500;
    public int dragonHealth = 500;
    public Animator animator;
    public Collider DragonCollider;
    public Rigidbody rb;

    [SerializeField] Healthbar healthbar;

    private void Awake()
    {
        healthbar = GetComponentInChildren<Healthbar>();
    }

    void start()
    {
        DragonCollider = GetComponent<Collider>();
        DragonCollider.isTrigger = true;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;   
        healthbar.UpdateHealthbar(dragonHealth, maxHP);

        LoadHealth(); 
    }

    void LoadHealth()
    {
        dragonHealth = PlayerPrefs.GetInt("DragonHealth", 500); 
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
        PlayerPrefs.SetInt("DragonHealth", dragonHealth);
        PlayerPrefs.Save(); 

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sword")
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        dragonHealth -= damageAmount;
        healthbar.UpdateHealthbar(dragonHealth, maxHP);

        if (dragonHealth<=0)
        {
            animator.SetTrigger("Die");
            loadEnd(); 
        }
        else
        {
            animator.SetTrigger("Damage");
        }
    }

    public void loadEnd()
    {
        SceneManager.LoadScene("YouWin");
    }

}
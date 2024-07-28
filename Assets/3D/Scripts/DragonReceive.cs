using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dragon : MonoBehaviour
{
    public int maxHP = 500;
    public int enemyHealth = 500;
    public Animator animator;
    public Collider DragonCollider;
    public Rigidbody rb;

    [SerializeField] Healthbar healthbar;

    private void Awake()
    {
        healthbar = GetComponentInChildren<Healthbar>();
    }

    void Start()
    {
        DragonCollider = GetComponent<Collider>();
        DragonCollider.isTrigger = true;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;   
        healthbar.UpdateHealthbar(enemyHealth, maxHP);
//Playerpref for enemyHealth
        LoadHealth(); 
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

    void LoadHealth()
    {
        enemyHealth = PlayerPrefs.GetInt("EnemyHealth", 500); 
    }
//End of Playerpref (enemyHealth)

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
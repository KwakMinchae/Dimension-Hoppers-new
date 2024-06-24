using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHP = 500;
    public int HP = 500;
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
        healthbar.UpdateHealthbar(HP, maxHP);
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
        HP -= damageAmount;
        healthbar.UpdateHealthbar(HP, maxHP);

        if (HP<=0)
        {
            //animator.SetTrigger("Dead 0");
            Destroy(orange);
        }
    }

}
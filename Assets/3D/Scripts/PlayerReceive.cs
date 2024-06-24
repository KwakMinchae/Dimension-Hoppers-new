using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReceive : MonoBehaviour
{
    public int maxHP = 500;
    public int HP = 500;
    //public Animator animator;
    public Collider PlayerCollider;
    //public Rigidbody rb;

    [SerializeField] PlayerHealthbar Playerhealthbar;

    private void Awake()
    {
        Playerhealthbar = GetComponentInChildren<PlayerHealthbar>();
    }

    void start()
    {
        PlayerCollider = GetComponent<Collider>();
        PlayerCollider.isTrigger = true;
        //rb = GetComponent<Rigidbody>();
        //rb.isKinematic = true;   
        Playerhealthbar.UpdatePlayerHealthbar(HP, maxHP);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        Playerhealthbar.UpdatePlayerHealthbar(HP, maxHP);

        if (HP<=0)
        {
            Debug.Log("Player is injured");
        }
        else
        {
            Debug.Log("Player is dead");
        }
    }

}
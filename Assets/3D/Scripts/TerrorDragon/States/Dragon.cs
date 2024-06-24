using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonReceive : MonoBehaviour
{
    public int HP = 500;
    public Animator animator;
    public Collider DragonCollider;
    public Rigidbody rb;

    void start()
    {
        DragonCollider = GetComponent<Collider>();
        DragonCollider.isTrigger = true;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;

        if (HP<=0)
        {
            animator.SetTrigger("Die");
        }
        else
        {
            animator.SetTrigger("Damage");
        }
    }

}

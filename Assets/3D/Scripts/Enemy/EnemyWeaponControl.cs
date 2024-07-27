using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponControl : MonoBehaviour
{
   public GameObject Sword;
   public bool CanAttack = true; 
   public float AttackCoolDown = 1.0f; 
   public AudioClip SwordAttackSound;
   public bool IsAttacking = false; 

   void Update()
   {
    if (true)
    {
        if (CanAttack)
        {
            SwordAttack();
        }
    }
   }

   public void SwordAttack()
   {
        IsAttacking = true;
        CanAttack = false; 
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCoolDown());
   }

   IEnumerator ResetAttackCoolDown()
   {
    StartCoroutine(ResetAttackBool());
    yield return new WaitForSeconds(AttackCoolDown);
    CanAttack = true; 
   }

   IEnumerator ResetAttackBool()
   {
    yield return new WaitForSeconds(1.0f);
    IsAttacking = false;
   }
}

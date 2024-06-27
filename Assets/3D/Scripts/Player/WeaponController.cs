using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
   public GameObject Sword;
   public bool CanAttack = true; 
   public float AttackCoolDown = 1.0f; 
   public AudioClip SwordAttackSound;

   void Update()
   {
    if (Input.GetKey(KeyCode.LeftShift) || Input.GetMouseButtonDown(0))
    {
        if (CanAttack)
        {
            SwordAttack();
        }
    }
   }

   public void SwordAttack()
   {
        CanAttack = false; 
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCoolDown());

   }

   IEnumerator ResetAttackCoolDown()
   {
    yield return new WaitForSeconds(AttackCoolDown);
    CanAttack = true; 
   }
}

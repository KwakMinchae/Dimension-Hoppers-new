using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponControl : MonoBehaviour
{
   public GameObject Sword;
   public bool CanAttack = true; 
   public float AttackCoolDown = 1.0f; 
   public AudioClip SwordAttackSound;

   public float lookRadius = 10f;
   Transform target; 
   UnityEngine.AI.NavMeshAgent agent; 

   void start()
   {
    target = PlayerTracker.instance.player.transform;
   }

   void Update()
   {
    float distance = Vector3.Distance(target.position, transform.position);
    if (distance <= lookRadius)
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

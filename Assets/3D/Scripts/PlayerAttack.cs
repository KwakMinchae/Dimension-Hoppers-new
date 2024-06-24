using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int damageAmount = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.gameObject.tag == "Enemy")
        {
            var DragonComponent = other.GetComponent<Dragon>();
            if (DragonComponent != null)
            {
                DragonComponent.TakeDamage(damageAmount);
                Debug.Log("It's colliding");
            }
        }
    }
}
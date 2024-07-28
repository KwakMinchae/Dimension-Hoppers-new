using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 300f; //detection range of player

    Transform target; 
    public NavMeshAgent agent; 
        float speed = 20f; 


    void Start()
    {
        target = PlayerTracker.instance.player.transform; //player
        agent = GetComponent<NavMeshAgent>(); //enemy
        agent.speed = speed; 
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, agent.transform.position); 
        agent.SetDestination(target.position);

        if (true) 
        {
            FaceTarget();
        }
    }

    void FaceTarget() //Rotates enemy so it faces toward players
    {
        Vector3 direction = (target.position - transform.position).normalized; 
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z)); 
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f); 
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; 
        Gizmos.DrawWireSphere(transform.position, lookRadius);  
    } 
}

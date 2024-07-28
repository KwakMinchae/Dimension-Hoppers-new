using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 300f; 

    Transform target; 
    //Transform target;
    public NavMeshAgent agent; 
        float speed = 20f; 

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerTracker.instance.player.transform;
        //target = GameObject.FindGameObjectWithTag("Player"); 
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed; 

        //float distance = Vector3.Distance(target.position, agent.transform.position); 
        //agent.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        //agent.destination = target.transform.position; 
        float distance = Vector3.Distance(target.position, agent.transform.position); 
        agent.SetDestination(target.position);

        if (true) 
        {
            FaceTarget();
        }
    }

    void FaceTarget()
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

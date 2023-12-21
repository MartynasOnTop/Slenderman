using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public int speed;
    public float viewDistance = 10;
    public float wanderDistance = 5;

    public Animator movement;

    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }
    private void Update()
    {
        var distance = Vector3.Distance(transform.position, target.position);

        if (distance < viewDistance)
        {
            agent.destination = target.position;
            movement.Play("Run");
        }
        else
        {
            movement.Play("Walk");
            if (agent.velocity == Vector3.zero)
            {
                var offset = Random.insideUnitSphere * wanderDistance;
                agent.destination = transform.position + offset;
                movement.Play("Idle");
            }
        }

        if (distance < 1f)
        {
            //JumpScare
        }
    }
}

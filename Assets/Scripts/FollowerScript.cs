using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class FollowerScript : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform player;
    float followDistance = 3.0f;
    float distance;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(player.position);
        distance = Vector3.Distance(transform.position, player.position);
        if (player != null)
        {
            if (followDistance <= distance)
            {
                agent.destination = player.position;
            }
            else
            {
                agent.isStopped = true;
                agent.ResetPath();
            }
        }
    }
}

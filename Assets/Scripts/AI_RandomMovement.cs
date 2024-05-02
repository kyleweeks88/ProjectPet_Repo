using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_RandomMovement : MonoBehaviour
{
    public NavMeshAgent navAgent;
    public float wanderRadius;

    public Transform centerPoint;

    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            Vector3 point;
            if(RandomPoint(centerPoint.position, wanderRadius, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.yellow, 1.0f);
                navAgent.SetDestination(point);
            }
        }
    }

    bool RandomPoint(Vector3 center, float radius, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * radius; //Creates random point in sphere
        NavMeshHit hit;
        if(NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            // the 1.0f is the max distance
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}

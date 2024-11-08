using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class AI_RandomMovement : MonoBehaviour
{
    [SerializeField] float radius = 20f;
    [SerializeField] bool debugBool;
    [SerializeField] bool hasPatrolPoint;
    [SerializeField] float currentWaitTime;
    [SerializeField] float startWaitTime;

    NavMeshAgent myAgent;
    Vector3 nextPos;
    Vector3 startPos;

    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        nextPos = transform.position;
        startPos = transform.position;
        currentWaitTime = startWaitTime;
    }

    private void Update()
    {
        RandomPatrol();
    }

    void RandomPatrol()
    {
        if (!hasPatrolPoint)
        {
            nextPos = RandomPointGenerator.GeneratePoint(startPos, radius);
            hasPatrolPoint = true;
        }

        if (hasPatrolPoint)
        {
            myAgent.SetDestination(nextPos);
            myAgent.isStopped = false;
            if (Vector3.Distance(nextPos, transform.position) <= myAgent.stoppingDistance)
            {
                myAgent.isStopped = true;
                hasPatrolPoint = false;
            }
        }
    }

    void OnDrawGizmos()
    {
        if (debugBool == true)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, nextPos);
        }
    }
}
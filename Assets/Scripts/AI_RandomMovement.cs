using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class AI_RandomMovement : MonoBehaviour
{
    [SerializeField] float radius = 20f;
    [SerializeField] bool debugBool;

    NavMeshAgent myAgent;
    Vector3 nextPos;
    Vector3 startPos;

    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        nextPos = transform.position;
        startPos = transform.position;
    }

    private void Update()
    {
        if(Vector3.Distance(nextPos, transform.position) <= 1.5f)
        {
            // START COROUTINE
            nextPos = RandomPointGenerator.PointGenerator(startPos, radius);
            myAgent.SetDestination(nextPos);
        }
    }

    void OnDrawGizmos()
    {
        if(debugBool == true)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, nextPos);
        }
    }
}
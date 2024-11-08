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
    [SerializeField] bool isWaiting;

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
        RandomPatrol();
    }

    void RandomPatrol()
    {
        if (!hasPatrolPoint && !isWaiting)
        {
            StopCoroutine(WaitTimer());
            nextPos = RandomPointGenerator.GeneratePoint(startPos, radius);
            hasPatrolPoint = true;
        }
        
        if (hasPatrolPoint)
        {
            myAgent.SetDestination(nextPos);
            myAgent.Resume();
            if (Vector3.Distance(nextPos, transform.position) <= myAgent.stoppingDistance)
            {
                myAgent.Stop();
                hasPatrolPoint = false;
                StartCoroutine(WaitTimer());
                Debug.Log("TEST");
            }
        }
    }

    IEnumerator WaitTimer()
    {
        isWaiting = true;

        yield return new WaitForSeconds(10f);

        isWaiting = false;
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
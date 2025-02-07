using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPath : MonoBehaviour
{
    public List<Transform> wayPoints;

    public NavMeshAgent agent;

    private int wayPointIndex = 0;

    private void Update()
    {
        if(agent.remainingDistance < .2f)
        {
            if (wayPointIndex < wayPoints.Count - 1)
                wayPointIndex++;
            else
                wayPointIndex++;
            agent.SetDestination(wayPoints[wayPointIndex].position );
        }
    }
}

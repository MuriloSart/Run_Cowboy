using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPath : MonoBehaviour
{
    public List<Transform> wayPoints;

    public List<NavMeshAgent> agents;

    private int wayPointIndex = 0;

    private int radomInt;

    private void Update()
    {
        foreach (NavMeshAgent agent in agents)
        {
            if (agent != null && agent.isActiveAndEnabled)
            {
                if (agent.remainingDistance < .2f)
                {
                    radomInt = UnityEngine.Random.Range(0, wayPoints.Count - 1);
                    agent.SetDestination(wayPoints[radomInt].position);
                }
            }
        }
    }
}

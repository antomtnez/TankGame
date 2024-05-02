using System;
using UnityEngine;
using UnityEngine.AI;

public class BaseMove : MonoBehaviour
{
    protected NavMeshAgent agent;
    [SerializeField]
    protected int maxRangeToMove = 10;
    protected bool hasNewDestination = false;

    public event Action OnDestinationReached;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    
    public bool IsAgentDestinationReached()
    {
        if(hasNewDestination)
        {
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                if(!agent.hasPath || agent.velocity.sqrMagnitude == 0f){
                    hasNewDestination = false;
                    return true;
                } 
            }
        }
        return false;
    }
}

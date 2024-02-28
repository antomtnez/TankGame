using UnityEngine;
using UnityEngine.AI;

public class AIMove : BaseMove, IMovable
{
    [SerializeField]
    private Transform target;
    private int minDistanceToTarget = 4;

    public void Move()
    {
        if(target == null) target = GameObject.FindGameObjectWithTag("Player").transform;
        if(target != null)
        {
            float distance = Vector3.Distance(target.position, transform.position);
            if(distance <= maxRangeToMove)
            {
                Vector3 randomPoint;
                do{
                    Vector2 randomPointInMaxRange = UnityEngine.Random.insideUnitCircle * maxRangeToMove;
                    randomPoint = transform.position + new Vector3(randomPointInMaxRange.x, 0f, randomPointInMaxRange.y);
                }while (Vector3.Distance(randomPoint, target.position) > minDistanceToTarget);

                agent.SetDestination(randomPoint);
                hasNewDestination = true;
            }
            else
            {
                Vector3 directionToTarget = (target.position - transform.position).normalized;
                Vector3 positionInRange = transform.position + directionToTarget * maxRangeToMove;
                if (NavMesh.SamplePosition(positionInRange, out NavMeshHit hit, maxRangeToMove, NavMesh.AllAreas)) {
                    agent.SetDestination(hit.position);
                    hasNewDestination = true;
                }
            }
        }
    }
}

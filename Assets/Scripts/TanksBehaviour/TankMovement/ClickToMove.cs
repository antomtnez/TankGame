using UnityEngine;

public class ClickToMove : BaseMove, IMovable
{
    public void Move()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(!IsDestinationPointInDistance(hit.point))
                {
                    Debug.Log("This point is too long to move");
                }else{
                    agent.SetDestination(hit.point);
                    hasNewDestination = true;
                }
            }
        }
    }

    bool IsDestinationPointInDistance(Vector3 destinationPoint)
    {
        return Vector3.Distance(this.gameObject.transform.position, destinationPoint) <= maxRangeToMove;
    }
}

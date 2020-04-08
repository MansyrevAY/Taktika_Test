using UnityEngine;

[RequireComponent(typeof(GoToWaypoint))]
public class WaypointNavigator : MonoBehaviour
{
    GoToWaypoint controller;
    public Waypoint currentWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<GoToWaypoint>();
        controller.SetDestination(currentWaypoint.GetPosition());
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.reachedDestination)
        {
            if (currentWaypoint.branches.Count > 0)
            {
                currentWaypoint = currentWaypoint.branches[Random.Range(0, currentWaypoint.branches.Count)];
            }
            else
            {
                if (currentWaypoint.nextWaypoint == null)
                    return;

                currentWaypoint = currentWaypoint.nextWaypoint;
            }
            controller.SetDestination(currentWaypoint.GetPosition());
        }
    }
}

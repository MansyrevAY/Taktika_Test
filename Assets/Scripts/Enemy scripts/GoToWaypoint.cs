using UnityEngine;

public class GoToWaypoint : MonoBehaviour
{
    public float movementSpeed;
    public float stopDistance;

    public Vector3 Destination
    {
        get;
        protected set;
    }

    public bool reachedDestination
    {
        get;
        protected set;
    }

    private void Start() => reachedDestination = false;

    // Update is called once per frame
    void Update()
    {
        if(transform.position != Destination)
        {
            Vector2 destinationDirection = Destination - transform.position;

            float destinationDistance = destinationDirection.magnitude;

            if(destinationDistance >= stopDistance)
            {
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.Translate(destinationDirection.normalized * movementSpeed * Time.deltaTime);
            }

            else
            {
                reachedDestination = true;
            }
        }
    }

    public void SetDestination(Vector3 target)
    {
        Destination = target;
        reachedDestination = false;
    }


}

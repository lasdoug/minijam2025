using UnityEngine;

public class PlayButtonMovement : MonoBehaviour
{
    public float speed;
    public float range;
    public float maxDistance;

    Vector2 wayPoint;

    //Makes the Button have somewhere to head to at the start of the game
    void Start()
    {
        SetNewDestination();
    }

    // Update is called once per frame
    void Update()
    {
        //Moves from current position to wayPoint 
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
        //Sets up new destination once we are close enough to current waypoint
        if (Vector2.Distance(transform.position, wayPoint) < range)
        {
            SetNewDestination();
        }
    }


    //Gets the PlayButton to have a new wayPoint to head towards
    void SetNewDestination ()
    {
        wayPoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));

    }
}

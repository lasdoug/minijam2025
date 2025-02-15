using UnityEngine;

public class PlayButtonMovement : MonoBehaviour
{
    private float speed;
    private float range;
    private float maxDistanceX;
    private float maxDistanceY;

    Vector2 wayPoint;

    //Makes the Button have somewhere to head to at the start of the game
    void Start()
    {
        //SetNewDestination();
        speed = 0;
        range = 0;
        maxDistanceX = 0;
        maxDistanceY = 0;
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
        wayPoint = new Vector2(Random.Range(-maxDistanceX, maxDistanceX), Random.Range(-maxDistanceY, maxDistanceY));

    }

    public void RunAway()
    {
        speed = 5;
        range = 0.05f;
        maxDistanceX = 7;
        maxDistanceY = 4;
        SetNewDestination();
    }

    public void SlowRunAway()
    {
        speed = 3;
    }
}

using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class PlayButtonMovement : MonoBehaviour
{
    private float speed;
    private float range;
    private float maxDistanceX;
    private float maxDistanceY;

    private float timeSinceLastRan=0f;
    public float runDelay=2f;

    Vector2 wayPoint;
    private GameObject cursor;
    Vector2 awayVector;
    public Ease aversion=Ease.Linear;

    //Makes the Button have somewhere to head to at the start of the game
    void Start()
    {
        //SetNewDestination();
        timeSinceLastRan = runDelay;
        speed = 0;
        range = 0.05f;
        maxDistanceX = 7;
        maxDistanceY = 4;
        cursor = GameObject.FindGameObjectsWithTag("Pointer")[0];
        if(cursor == null) Debug.Log("No cursor found!!");
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastRan += Time.deltaTime;
        if(timeSinceLastRan < runDelay){
            transform.position = Vector2.MoveTowards(transform.position, awayVector, speed * Time.deltaTime);
        }
        else{
            //Moves from current position to wayPoint
            transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
        }

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

    public void RunAwayWithAversion(){
        if(timeSinceLastRan < runDelay) return;

        timeSinceLastRan=0;

        awayVector = new Vector2(transform.position.x - cursor.transform.position.x, transform.position.y - cursor.transform.position.y);
        awayVector *= 6;
        DOTween.To(()=>awayVector, x=>awayVector=x, wayPoint, 2f).SetEase(aversion);
        
        speed = 5;
        SetNewDestination();
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

using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.Windows.Speech;

public class PlayButtonMovement : MonoBehaviour
{
    private float speed;
    private float range;
    private float maxDistanceX;
    private float maxDistanceY;

    private float timeSinceLastRan=0f;
    public bool startRunning { get; set; } = false;
    public float runDelay=2f;

    Vector2 wayPoint;
    private GameObject cursor;
    Vector2 awayVector;
    public Ease aversion=Ease.Linear;
    private Rigidbody2D body;

    delegate void Move();
    Move moveFunc=null;
    public float directRunSpeed = 10f;

    //Makes the Button have somewhere to head to at the start of the game
    void Start()
    {
        //SetNewDestination();
        timeSinceLastRan = runDelay;
        body = gameObject.GetComponent<Rigidbody2D>();
        speed = 0;
        range = 0.05f;
        maxDistanceX = 7;
        maxDistanceY = 4;
        cursor = GameObject.FindGameObjectsWithTag("Pointer")[0];
        if(cursor == null) Debug.Log("No cursor found!!");
    }

    void MoveToWaypoint(){
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
    }

    void MoveAwayWithAversion(){
        if(timeSinceLastRan < runDelay){
            transform.position = Vector2.MoveTowards(transform.position, awayVector, speed * Time.deltaTime);
        }
        else{
            moveFunc = MoveToWaypoint;
        }
    }

    void MoveBookIt(){
        speed = 5;
        if(timeSinceLastRan > runDelay){
            moveFunc = MoveToWaypoint;
            return;
        }

        float dist = Vector2.Distance(transform.position, cursor.transform.position);
        if(dist < 3){
            body.AddForce(new Vector2(transform.position.x - cursor.transform.position.x, transform.position.y - cursor.transform.position.y).normalized * (directRunSpeed/dist));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!startRunning)
        {
            return;
        }
        timeSinceLastRan += Time.deltaTime;
        if(moveFunc != null) moveFunc();
        //Sets up new destination once we are close enough to current waypoint
        if (Vector2.Distance(transform.position, wayPoint) < range)
        {
            SetNewDestination();
        }

        //if we've run offscreen come back please
        if(transform.position.x < -10 || transform.position.x > 10){
            transform.position = new Vector2(transform.position.x * -1, transform.position.y);
        }
        if(transform.position.y < -6 || transform.position.y > 6){
            transform.position = new Vector2(transform.position.x, transform.position.y * -1);
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
        moveFunc = MoveAwayWithAversion;
    }

    public void BookItOffscreen(){
        timeSinceLastRan = 0;
        moveFunc = MoveBookIt;
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

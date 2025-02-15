using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using DG.Tweening;

public class MouseControls : MonoBehaviour
{
    private Mouse mouse;
    private Rigidbody2D body;
    public bool isSlippy {get; set;}=false;
    public int mouseSlowFactor=100;
    public float timeoutLen = 1f;
    private float timeoutCounter = -1f;
    public float reboundMagnitude = 20f;
    public float torque = 0.99f;
    public float tween=1f;
    public Ease ease;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mouse = Mouse.current;
        body = gameObject.GetComponent<Rigidbody2D>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        // if(transform.eulerAngles.z != 0){
        //     AttemptToUnrotate();
        // }
        

        if(timeoutCounter > -1){
            timeoutCounter += Time.deltaTime;
            if(timeoutCounter >= timeoutLen) timeoutCounter = -1;
            return;
        }

        if(!isSlippy) NormalMouseMove();
        else ApplyForceToMouse();
    }
    private void AttemptToUnrotate(){
        //transform.eulerAngles = transform.eulerAngles * torque;
    }
    private void NormalMouseMove(){
        Vector2Control v = mouse.delta;
        float x = v.x.ReadValue()/mouseSlowFactor;
        float y = v.y.ReadValue()/mouseSlowFactor;
        transform.position += new Vector3(x,y,0);
    }
    private void ApplyForceToMouse(){
        Vector2Control v = mouse.delta;
        float x = v.x.ReadValue();
        float y = v.y.ReadValue();
        body.AddForce(new Vector2(x,y) * tween);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(timeoutCounter > -1) return;
        
        if(isSlippy && collision.collider.CompareTag("Bound")){
            body.AddForce(collision.relativeVelocity * reboundMagnitude);
            transform.DOPunchScale(new Vector3(0.5f,0.5f,0.5f), timeoutLen, 10, 0.5f);
            tween = 0;
            DOTween.To(()=>tween, x=>tween=x, 1, timeoutLen).SetEase(ease);
        }
    }
}
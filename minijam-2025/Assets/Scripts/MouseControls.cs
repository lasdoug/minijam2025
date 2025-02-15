using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using DG.Tweening;

public class MouseControls : MonoBehaviour
{
    private Mouse mouse;
    private Rigidbody2D body;
    public bool isSlippy=false;
    public int mouseSlowFactor=100;
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
        if(!isSlippy) NormalMouseMove();
        else ApplyForceToMouse();
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
        body.AddForce(new Vector2(x,y));
    }
}

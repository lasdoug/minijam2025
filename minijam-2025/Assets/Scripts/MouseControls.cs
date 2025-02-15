using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using DG.Tweening;

public class MouseControls : MonoBehaviour
{
    private Mouse mouse;
    private Rigidbody2D body;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mouse = Mouse.current;
        body = gameObject.GetComponent<Rigidbody2D>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        MouseTest();
    }
    private void MouseTest(){
        Vector2Control v = mouse.delta;
        float x = v.x.ReadValue();
        float y = v.y.ReadValue();
        body.AddForce(new Vector2(x,y));
    }
}

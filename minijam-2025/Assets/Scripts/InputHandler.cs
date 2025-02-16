using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    //Referencing the main camera
    private Camera _maincamera;

    private void Awake()
    {
        _maincamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        //If not clicked
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_maincamera.ScreenPointToRay(pos:(Vector2)Mouse.current.position.ReadValue()));
        //Checks if clicking object with a colllider
        if (!rayHit.collider) return;

        Debug.Log("clicked");
    }
}

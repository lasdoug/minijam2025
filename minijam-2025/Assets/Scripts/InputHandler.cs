using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    //Referencing the main camera
    private Camera _maincamera;
    public GameObject clickBit;

    private void Awake()
    {
        _maincamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        //If not clicked
        if (!context.started) return;

        Debug.Log("clicked???");
        //var rayHit = Physics2D.GetRayIntersection(_maincamera.ScreenPointToRay(pos:clickBit.transform.position));
        var rayHit = Physics2D.GetRayIntersection(new Ray(clickBit.transform.position, Vector2.down));
        //Checks if clicking object with a colllider
        if (!rayHit.collider) return;

        Debug.Log("clicked");
    }
}

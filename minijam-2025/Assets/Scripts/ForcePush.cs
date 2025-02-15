using UnityEngine;

public class ForcePush : MonoBehaviour
{
    public Rigidbody2D cursorRb;

    public void push()
    {
        cursorRb.AddForce(Vector2.up * 500);
    }
}

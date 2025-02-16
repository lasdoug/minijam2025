using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    
    public GameObject clickBit;

    public void OnClick(InputAction.CallbackContext context)
    {
        //If not clicked
        if (!context.started) return;

        Collider2D collider = Physics2D.OverlapPoint(clickBit.transform.position, layerMask: 1, minDepth: -100f, maxDepth: -1f);
        //Checks if clicking object with a colllider
        if (collider != null && collider.gameObject.CompareTag("Enemy"))
        {
            if(!collider.gameObject.CompareTag("Enemy")) return;
            GameObject monsta = collider.gameObject.transform.parent.gameObject;
            monsta.GetComponent<Monster>().Kill();
        }
        
        

    }
}

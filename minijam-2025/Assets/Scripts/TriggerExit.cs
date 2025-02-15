using UnityEngine;
using UnityEngine.Events;

public class TriggerExit : MonoBehaviour
{
    public UnityEvent onTrigger;
    private void OnTriggerExit2D(Collider2D other)
    {
        onTrigger.Invoke();
    }
}

using System; 
using UnityEngine;
using UnityEngine.Events;

public class RunAway : MonoBehaviour
{
    public UnityEvent OnTriggered;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pointer"))
        {
            print("RUNAWAY!!");
            OnTriggered.Invoke();
        }
    }
}

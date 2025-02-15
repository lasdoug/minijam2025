using System; 
using UnityEngine;
using UnityEngine.Events;

public class RunAway : MonoBehaviour
{
    public UnityEvent onTrigger;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hi");
        if (other.CompareTag("Pointer"))
        {
            onTrigger.Invoke();
            print("RUNAWAY");
        }
    }

    private void Start()
    {
        print("Hello :)");
    }
    /* public UnityEvent OnTriggered;
     private void OnTriggerEnter2D(Collider2D other)
     {
         if (other.CompareTag("Pointer"))
         {
             print("RUNAWAY!!");
             OnTriggered.Invoke();
         }
     }
    */
}

using UnityEngine;

public class MouseWakeUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("WakeUp", 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

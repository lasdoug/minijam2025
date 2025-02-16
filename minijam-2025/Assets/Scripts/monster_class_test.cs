using UnityEngine;
using System;

// Monster class
public class Monster : MonoBehaviour
{
    // Assign values in Unity Inspector
    public string monster_name;
    public int score_value;

    // Declare event for monster kill
    public static event Action<int> OnKill;

    // Kill method (called automatically in Start for testing)
    public void Kill()
    {
        Debug.Log(monster_name + " killed!! Score: +" + score_value);

        // Trigger OnKill event
        OnKill?.Invoke(score_value);

        // Destroy monster object
        Destroy(gameObject);
    }

    // Kill monster automatically when the scene starts (for testing)
    void Start()
    {
        Kill();
    }
}

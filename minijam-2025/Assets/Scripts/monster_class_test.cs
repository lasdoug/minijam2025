using UnityEngine;
using System;

// Monster class (test)
public class Monster : MonoBehaviour
{
    // Initialise variables
    private string monster_name;
    private int score_value;

    // Constructor
    public void Initialise(string name, int score_value)
    {
        this.monster_name = name;
        this.score_value = score_value;
    }

    // Declare kill monster event
    public static event Action<int> OnKill;

    // Kill method
    public void Kill()
    {
        Debug.Log(monster_name + " killed!! Score: +" + score_value);

        // Trigger OnKill event
        OnKill?.Invoke(score_value);

        // Destroy monster object
        Destroy(gameObject);
    }

}
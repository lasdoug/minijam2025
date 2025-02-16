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
        Debug.Log(gameObject.name + "killed!! Score: +" + score_value);

        // Trigger OnKill event
        OnKill?.Invoke(score_value);

        // Destroy monster object
        Destroy(gameObject);
    }

}

public class Scoring : MonoBehaviour 
{
    // Variables
    private int total_score = 0;

    // Update score 
    void OnEnable()
    {
        // Subscribe to Monster event
        Monster.OnKill += UpdateScore;
    }

    void OnDisable()
    {
        // Unsubscribe to Monster event
        Monster.OnKill -= UpdateScore;
    }

    void UpdateScore(int score)
    {
        total_score += score;
        Debug.Log("Total Score: " + total_score);
    }

    // Test 
    void Start() 
    {
        GameObject monster_1_object = new GameObject("Monster1");
        Monster monster_1 = monster_1_object.AddComponent<Monster>();
        monster_1.Initialise("Monster 1", 10);

        GameObject monster_2_object = new GameObject("Monster2");
        Monster monster_2 = monster_2_object.AddComponent<Monster>();
        monster_2.Initialise("Monster 2", 20);

        monster_1.Kill();
        monster_2.Kill();
    }
}
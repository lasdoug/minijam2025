using UnityEngine;
using System;

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
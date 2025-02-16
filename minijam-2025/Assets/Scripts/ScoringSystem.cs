using UnityEngine;

public class Scoring : MonoBehaviour
{
    private int total_score = 0;

    void OnEnable()
    {
        Monster.OnKill += UpdateScore;
    }

    void OnDisable()
    {
        Monster.OnKill -= UpdateScore;
    }

    void UpdateScore(int score)
    {
        total_score += score;
        Debug.Log("Total Score: " + total_score);
    }
}

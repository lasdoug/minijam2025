using UnityEngine;
using TMPro; // TextMeshPro

public class Scoring : MonoBehaviour
{
    private int total_score = 0;
    public TMP_Text score_text;
    public TMP_Text final_score_text;

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

        // ✅ Ensure TMP_Text is updating
        if (score_text != null)
        {
            score_text.text = "Total Score: " + total_score;
        }
        else
        {
            // Debug.LogError("ScoreText (TMP) UI is not assigned!");
        }
    }

    void Start()
    {
        if (final_score_text != null)
        {
            final_score_text.text = "Final Score: " + total_score;
        }
    }
    
}

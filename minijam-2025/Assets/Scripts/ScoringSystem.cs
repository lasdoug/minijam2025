using UnityEngine;
using TMPro; // TextMeshPro

public class Scoring : MonoBehaviour
{
    private int total_score = 0;
    public TMP_Text score_text; 

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
            Debug.LogError("ScoreText (TMP) UI is not assigned!");
        }
    }
}

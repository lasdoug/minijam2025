using UnityEngine;
using TMPro; // TextMeshPro

public class Scoring : MonoBehaviour
{
    public static Scoring Instance;
    public int total_score;
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
        PlayerPrefs.SetInt("total_score", total_score);
        // Debug.Log("Total Score: " + total_score);

        // Ensure TMP_Text is updating
        if (score_text != null)
        {
            score_text.text = "Total Score: " + total_score;
        }
    }

    void Awake()
    {
        PlayerPrefs.SetInt("total_score", 0);
    }
}

using TMPro;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    public TMP_Text final_score_text;

    void Start()
    {
        final_score_text.text = "Final Score: " + PlayerPrefs.GetInt("total_score", 0).ToString();
    }
}

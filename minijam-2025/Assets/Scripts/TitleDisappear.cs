using UnityEngine;
using DG.Tweening;
using TMPro;

public class TitleDisappear : MonoBehaviour
{
    public TMP_Text text;
    public float duration;
    
    // float size = 0;
    float alpha = 0;

    float getAlpha()
    {
        return alpha;
    }

    void setAlpha(float a)
    {
        alpha = a;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void FadeText()
    {
        // DOTween.To(() => size, x => size = x, 50f, 5f).OnUpdate(SizeText);
        DOTween.To(getAlpha, setAlpha, 1f, duration).OnUpdate(SortText).From();
    }

    // void SizeText()
    // {
    //     text.fontSize = size;
    // }
    
    

    void SortText()
    {
        var t = text.color;
        t.a = alpha;
        text.color = t;
    }
}
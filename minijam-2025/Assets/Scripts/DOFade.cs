using System;
using DG.Tweening;
using UnityEngine;

public class DOFade : MonoBehaviour
{
    public void Fade(GameObject target)
    {
        var sprite = target.GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.DOFade(0f, 1f);
        }
    }

}

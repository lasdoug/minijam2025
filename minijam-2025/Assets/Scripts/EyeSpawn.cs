using DG.Tweening;
using UnityEngine;

public class EyeSpawn : MonoBehaviour
{
    public float duration;
    public float scaleAmount;
    public Ease easeType;
    public void SpawnAnimation()
    {
        transform.DOScale(scaleAmount, duration) .SetEase(easeType);
    }
}

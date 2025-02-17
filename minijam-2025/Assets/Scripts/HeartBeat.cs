using DG.Tweening;
using UnityEngine;

public class HeartBeat : MonoBehaviour
{
    public void OnEnable()
    {
        transform.DOScale(1.2f, 0.5f) .SetEase(Ease.OutBounce) .SetLoops(-1, LoopType.Yoyo);
    }
}

using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class StartGame : MonoBehaviour
{
    public UnityEvent onTrigger;
    private void OnTriggerEnter2D(Collider2D other)
    {
        onTrigger.Invoke();
    }

}

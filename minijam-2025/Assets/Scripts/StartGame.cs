using System;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("triggered");
    }
}

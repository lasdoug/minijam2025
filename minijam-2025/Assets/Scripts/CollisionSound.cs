using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        if (audioSource == null)
        {
            Debug.LogError("AudioSource not assigned in the inspector.");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}

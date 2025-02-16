using UnityEngine;
using System;

// Monster class
public class Monster : MonoBehaviour
{
    // Assign values in Unity Inspector
    public string monster_name;
    public int score_value;
    public GameObject spawner;

    // Declare event for monster kill
    public static event Action<int> OnKill;

    void Start()
    {
        spawner = GameObject.FindGameObjectsWithTag("spawner")[0];
    }

    // Kill method (called automatically in Start for testing)
    public void Kill()
    {
        Debug.Log(monster_name + " killed!! Score: +" + score_value);

        // Trigger OnKill event
        OnKill?.Invoke(score_value);

        if(gameObject.CompareTag("PlayButton") && spawner != null){
            spawner.SetActive(true);
        }
        else
        {
            spawner.GetComponent<Spawner>().RemoveMonster();
        }

        // Destroy monster object
        Destroy(gameObject);
    }

    
}

using UnityEngine;
using System;

// Monster class
public class Monster : MonoBehaviour
{
    // Assign values in Unity Inspector
    public string monster_name;
    public int score_value;
    private Spawner spawner;
    private EnemySpawner enemySpawner;

    // Declare event for monster kill
    public static event Action<int> OnKill;

    void Start()
    {
        spawner = FindAnyObjectByType<Spawner>();
        if (spawner == null)
        {
            Debug.Log("No Spawner");
        }

        enemySpawner = FindAnyObjectByType<EnemySpawner>();
        if (enemySpawner == null)
        {
            Debug.Log("No Enemy Spawner");
        }
    }

    // Kill method (called automatically in Start for testing)
    public void Kill()
    {
        // Debug.Log(monster_name + " killed!! Score: +" + score_value);

        // Trigger OnKill event
        OnKill?.Invoke(score_value);
        spawner.RemoveMonster();

        if(gameObject.CompareTag("PlayButton"))
        {
            spawner.StartSpawning();
            enemySpawner.StartSpawning();

        }
        // else
        // {
        //     
        // }
        // Destroy monster object
        Destroy(gameObject);
    }

    
}

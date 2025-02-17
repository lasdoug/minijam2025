using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate = 2;
    private float timer;
    private Vector3 spawnLocation;
    public int maxMonsters;
    public int monsterCounter;
    public bool isSpawning;

    Vector3 PickSpawnLocation()
    {
        var x = Random.Range(-10f, 10f);
        var y = Random.Range(-5f, 5f);
        spawnLocation.Set(x, y, -2);
        return spawnLocation;
    }
    
    void SpawnMonster()
    {
        if (isSpawning)
        {
        Instantiate(enemy, PickSpawnLocation(), transform.rotation);
        monsterCounter++;
        }
    }
    void Update()
    {
        if (isSpawning)
        {
            if (monsterCounter < maxMonsters)
            {
                if (timer < spawnRate)
                {
                    timer += Time.deltaTime;
                }
                else
                {
                    SpawnMonster();
                    timer = 0;
                }
            }
        }
    }

    public void RemoveMonster()
    {
        monsterCounter--;
    }

    public void StartSpawning()
    {
        isSpawning = true;
        SpawnMonster();
    }
}

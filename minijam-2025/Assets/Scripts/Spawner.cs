using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate = 2;
    public int maxMonsters;
    public int monsterCounter;
    public bool isSpawning;
    public int zIndex;
    
    private float timer;
    private SpriteRenderer enemyBodySpriteRenderer;
    private Vector3 spawnLocation;


    Vector3 PickSpawnLocation()
    {
        var x = Random.Range(-9f, 9f);
        var y = Random.Range(-4f, 4f);
        spawnLocation.Set(x, y, -2);
        return spawnLocation;
    }
    
    void SpawnMonster()
    {
        if (isSpawning)
        {
            GameObject newEnemy = Instantiate(enemy, PickSpawnLocation(), transform.rotation);
            enemyBodySpriteRenderer = newEnemy.GetComponent<SpriteRenderer>();
            enemyBodySpriteRenderer.sortingOrder = zIndex;
            zIndex++;
            monsterCounter++;
            for (int i = 0; i < newEnemy.transform.childCount; i++)
            {
                newEnemy.transform.GetChild(i).GetComponent<SpriteRenderer>().sortingOrder = zIndex;
            }
            zIndex++;
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

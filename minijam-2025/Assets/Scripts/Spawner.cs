using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate = 2;
    private float timer;
    private Vector3 spawnLocation;
    public int maxMonsters;
    [SerializeField] int monsterCounter;

    Vector3 PickSpawnLocation()
    {
        var x = Random.Range(-10f, 10f);
        var y = Random.Range(-5f, 5f);
        spawnLocation.Set(x, y, -2);
        return spawnLocation;
    }

    void Update()
    {
        if (monsterCounter < maxMonsters)
        {
            if (timer < spawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                Instantiate(enemy, PickSpawnLocation(), transform.rotation);
                timer = 0;
                monsterCounter++;
            }
        }
    }


}

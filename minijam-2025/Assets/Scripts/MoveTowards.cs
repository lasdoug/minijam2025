using Unity.VisualScripting;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public GameObject LittleMonster;
    public GameObject Cursor;
    public float minSpeed;
    public float maxSpeed;
    private float speed;
    private EnemySpawner enemySpawner;

    void Start()
    {
        Cursor = GameObject.FindGameObjectsWithTag("PointerContainer")[0];
        enemySpawner = FindAnyObjectByType<EnemySpawner>();
        speed = Random.Range(minSpeed, maxSpeed);
    }
    // Update is called once per frame
    void Update()
    {
        LittleMonster.transform.position = Vector2.MoveTowards(LittleMonster.transform.position, Cursor.transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("PointerContainer")) {
            HealthManager.health--;
            Cursor.GetComponent<Rigidbody2D>().AddForce(collision.relativeVelocity * -70);
            Destroy(gameObject);
            enemySpawner.RemoveMonster();
        }

        else if(collision.collider.GetComponent<Rigidbody2D>() != null){
            print("boing");
            Vector2 hereToOther = new Vector2(collision.collider.transform.position.x - transform.position.x, collision.collider.transform.position.y - transform.position.y).normalized;
            float magnitude = Random.Range(40f, 100f);
            collision.collider.GetComponent<Rigidbody2D>().AddForce(hereToOther * magnitude);
            gameObject.GetComponent<Rigidbody2D>().AddForce(hereToOther * -magnitude);
        }
    }
}


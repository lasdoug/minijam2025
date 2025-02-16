using Unity.VisualScripting;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public GameObject LittleMonster;
    public GameObject Cursor;
    public float speed;

    void Start()
    {
        Cursor = GameObject.FindGameObjectsWithTag("PointerContainer")[0];
    }
    // Update is called once per frame
    void Update()
    {
        LittleMonster.transform.position = Vector2.MoveTowards(LittleMonster.transform.position, Cursor.transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("collided");
        if (collision.collider.CompareTag("PointerContainer")) {
            gameObject.SetActive(false);
            HealthManager.health--;
            Cursor.GetComponent<Rigidbody2D>().AddForce(collision.relativeVelocity * -70);
        }
    }
}


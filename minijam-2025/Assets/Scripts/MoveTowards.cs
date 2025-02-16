using Unity.VisualScripting;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public GameObject LittleMonster;
    public GameObject Cursor;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        LittleMonster.transform.position = Vector2.MoveTowards(LittleMonster.transform.position, Cursor.transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Pointer") {
           gameObject.SetActive(false);
            HealthManager.health--;
        }
    }
}


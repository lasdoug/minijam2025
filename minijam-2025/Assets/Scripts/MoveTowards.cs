using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public GameObject LittleMonster;
    public GameObject Cursor;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        LittleMonster.transform.position = Vector2.MoveTowards(LittleMonster.transform.position, Cursor.transform.position, speed);
    }
}

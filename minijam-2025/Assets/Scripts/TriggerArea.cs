using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public GameObject over = null;
    void OnTriggerEnter2D(Collider2D other)
    {
        //print("in");
        if(other.gameObject.CompareTag("Enemy")){
            //print("entered middle");
            over = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        //print("out");
        if(other.gameObject.CompareTag("Enemy")){
            //print("left middle");
            over = null;
        }
    }
}

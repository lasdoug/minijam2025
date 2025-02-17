using UnityEngine;

public class ForcePush : MonoBehaviour
{
    public float pushAmount;
    public void push(GameObject target)
    {
        var body = target.GetComponent<Rigidbody2D>();
        if (body != null)
        {
            var direction = (target.transform.position - transform.position).normalized;
            body.AddForce(direction * pushAmount, ForceMode2D.Impulse);
        }
    }
}

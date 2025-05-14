using UnityEngine;

public class Collider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CollidingObject"))
        {
            Debug.Log("Collided with CollisionObject");
        }
    }
}

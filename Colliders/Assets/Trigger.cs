using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.CompareTag("CollidingObject"))
        {
            Debug.Log("Trigger is triggered by CollidingObject");
        }
    }
}

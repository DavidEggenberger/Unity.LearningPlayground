using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offset;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.1f);

        transform.position = smoothedPosition;
        transform.LookAt(target); // Optional: camera looks at the target
    }
}

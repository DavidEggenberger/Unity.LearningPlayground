using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform followTarget;
    public float followSpeed = 5;
    private Vector3 offset;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = followTarget.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (followTarget)
        {
            transform.position = followTarget.position - offset;
        }
    }
}

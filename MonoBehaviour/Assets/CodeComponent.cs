using UnityEngine;

public class CodeComponent : MonoBehaviour
{
    private void OnEnable()
    {
        Debug.Log("I am enabled");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        Debug.Log("I am disabled");
    }
}

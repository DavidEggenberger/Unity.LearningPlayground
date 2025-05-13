using System.Collections;
using UnityEngine;

public class MonoBehaviourTutorial : MonoBehaviour
{
    private Material groundMaterial;
    private Renderer renderer;
    private Coroutine coroutine;

    // Function is called when the GameObject becomes active
    private void OnEnable()
    {
        groundMaterial = Resources.Load<Material>("Materials/Ground");
        renderer = GetComponent<Renderer>();
        coroutine = StartCoroutine(BackgroundJob());

        gameObject.AddComponent<CodeComponent>();
    }

    private void Awake()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        yield return coroutine;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator BackgroundJob()
    {
        while (transform)
        {
            yield return new WaitForSeconds(1);
            renderer.material = groundMaterial;

            if (gameObject.TryGetComponent<CodeComponent>(out var component))
            {
                Destroy(component);
            }
        }
    }
}

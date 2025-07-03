using System.Collections;
using UnityEngine;

public class WalkingScript : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private bool isWalking;
    private bool isBoxing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(AnimationCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator AnimationCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            
            if (isWalking)
            {
                isBoxing = true;
                animator.SetBool("IsBoxing", isBoxing);
                isWalking = false;
                yield return new WaitForSeconds(10);
            }

            if (!isWalking && isBoxing)
            {
                isBoxing = false;
                animator.SetBool("IsBoxing", isBoxing);
                animator.SetBool("IsWalking", false);
                yield return new WaitForSeconds(10);
            }

            isWalking = !isWalking;
            animator.SetBool("IsWalking", isWalking);
        }
    }
}

using UnityEngine;
using UnityEngine.AI;

public class CharacterMovementScript : MonoBehaviour
{
    public NavMeshAgent playerNavMeshAgent;
    public Camera playerCamera;
    public Animator playerAnimator;
    private bool playerIsRunning;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) 
        { 
            Ray myRay = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(myRay, out hit))
            {
                playerNavMeshAgent.SetDestination(hit.point);
            }
        }

        if (playerNavMeshAgent.remainingDistance <= playerNavMeshAgent.stoppingDistance)
        {
            playerIsRunning = false;
        }
        else
        {
            playerIsRunning = true;
        }

        playerAnimator.SetBool("isRunning", playerIsRunning);
    }
}

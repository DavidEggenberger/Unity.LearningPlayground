using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.InputSystem.Controls;

public class RaycastSender : MonoBehaviour, Controls.IPlayerActions
{
    private Transform rayStartingPoint;
    private Transform rayEndingPoint;
    private Ray ray;
    private LineRenderer lineRenderer;

    void Awake()
    {
        rayStartingPoint = GetComponent<Transform>();
        rayEndingPoint = GameObject.FindWithTag("RayTarget")?.transform;
        lineRenderer = GetComponent<LineRenderer>();

        ray = new Ray(rayStartingPoint.position, (rayEndingPoint.position - rayStartingPoint.position).normalized);
    }

    private Controls controls;

    private void OnEnable()
    {
        if (controls != null)
            return;

        controls = new Controls();
        controls.Player.SetCallbacks(this);
        controls.Player.Enable();
    }

    public void OnDisable()
    {
        controls.Player.Disable();
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            lineRenderer.SetPosition(0, rayStartingPoint.position);
            lineRenderer.SetPosition(1, rayEndingPoint.position);        // End of ray (hit or max distance)
            if (Physics.Raycast(ray, out var hit, Vector3.Distance(rayStartingPoint.position, rayEndingPoint.position), Physics.AllLayers))
            {
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

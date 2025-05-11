using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    [SerializeField]
    private GameObject TravellingCube;

    [SerializeField]
    private List<Transform> Waypoints;

    private int nextWaypoint;

    private void OnEnable()
    {
        nextWaypoint = 1;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TravellingCube.transform.position = Waypoints[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var targetWaypoint = Waypoints[nextWaypoint];
        TravellingCube.transform.position = Vector3.MoveTowards(TravellingCube.transform.position, targetWaypoint.position, Time.deltaTime * 5);

        if (Vector3.Distance(TravellingCube.transform.position, targetWaypoint.transform.position) < 0.05f)
        {
            nextWaypoint++;
        }

        if (nextWaypoint == Waypoints.Count)
        {
            nextWaypoint = 0;
        }
    }
}

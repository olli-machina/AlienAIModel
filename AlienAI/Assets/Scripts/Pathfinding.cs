using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    public Transform[] searchLocations;
    private NavMeshAgent nav;
    private int nextPoint;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();   
    }


    private void FixedUpdate()
    {
        if (!nav.pathPending && nav.remainingDistance < 0.5f)
            GoToNextLocation();
    }

    void GoToNextLocation()
    {
        if (searchLocations.Length == 0)
            return;
        nav.destination = searchLocations[nextPoint].position;
        nextPoint = Random.Range(0, searchLocations.Length);
        if (searchLocations[nextPoint].position == nav.destination)
            nextPoint = (nextPoint + 1) % searchLocations.Length;
        Debug.Log(nextPoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

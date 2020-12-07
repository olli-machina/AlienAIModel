using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    public Transform[] searchLocations;
    private NavMeshAgent nav;
    private int nextPoint;
    public bool seePlayer = false;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
    }


    private void FixedUpdate()
    {
        seePlayer = HunterFOV.inFOV(transform, player.transform, 45f, 11.3f);
        if(seePlayer)
        {
            Debug.Log("Seen");
            Pursue();
        }
        else if (!nav.pathPending && nav.remainingDistance < 0.5f)
            GoToNextLocation();
    }

    public void GoToNextLocation()
    {
        if (searchLocations.Length == 0)
            return;
        nav.destination = searchLocations[nextPoint].position;
        nextPoint = Random.Range(0, searchLocations.Length);
        if (searchLocations[nextPoint].position == nav.destination)
            nextPoint = (nextPoint + 1) % searchLocations.Length;
    }

    public void Pursue()
    {
        if (!seePlayer)
            return;
        nav.destination = player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if(!player)
            player = GameObject.Find("Player");
    }
}

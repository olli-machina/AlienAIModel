using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    public Transform[] searchLocations; //get basics established, always have them
    public List<Transform> advancedLocations; //for when probability stars changing
    private NavMeshAgent nav;
    private int nextPoint;
    public bool seePlayer = false, fleeUsed = false;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        for(int i = 0; i < searchLocations.Length; i++)
        {
            advancedLocations.Add(searchLocations[i]);
        }
    }


    private void FixedUpdate()
    {
        seePlayer = HunterFOV.inFOV(transform, player.transform, 45f, 20f, 12f, 5f);
        if(seePlayer)
        {
            //Debug.Log("Seen");
            Pursue();
        }
        else if (!nav.pathPending && nav.remainingDistance < 1f)
            GoToNextLocation();
    }

    public void GoToNextLocation()
    {
        if (advancedLocations.Count == 0)
            return;
        nav.destination = searchLocations[nextPoint].position;
        nextPoint = Random.Range(0, advancedLocations.Count);
        if (searchLocations[nextPoint].position == nav.destination)
            nextPoint = (nextPoint + 1) % advancedLocations.Count;

    }

    public void Pursue()
    {
        if (!seePlayer)
        {
            GoToNextLocation();
            return;
        }
        nav.destination = player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if(!player)
            player = GameObject.Find("Player");
    }

    public void moreLikely(int index) //alien "learns" from player actions- searches in their common hiding spots
    {
        Debug.Log(advancedLocations.Count);
        advancedLocations.Add(searchLocations[index]);
        Debug.Log(advancedLocations.Count);
    }

    public void FleeAbility() //makes hunter faster if player keeps running away
    {
        if (!fleeUsed)
        {
            nav.speed += 3;
            fleeUsed = true;
        }
    }

    public void BackAbility()
    {

    }
}

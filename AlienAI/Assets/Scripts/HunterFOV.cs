using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterFOV : MonoBehaviour
{
    GameObject player;
    public float fovRange = 68.0f;
    float minDetectDistance;
    float rayRange;
    Vector3 facingDirection = Vector3.zero;
    public bool pursue = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        pursue = CanSeePlayer();
        if(pursue)
        {
            Hunt();
        }
    }

    public bool CanSeePlayer()
    {
        RaycastHit hit;
        facingDirection = player.transform.position - transform.position;
        float distToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if(Vector3.Angle(facingDirection, transform.forward) <= fovRange * 0.5f)
        {
            if (Physics.Raycast(transform.position, facingDirection, out hit, minDetectDistance))
            {
                return (hit.transform.CompareTag("Player"));
            }
        }
     
        return false;
    }

    public void Hunt()
    {

    }
}

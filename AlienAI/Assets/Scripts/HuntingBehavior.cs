using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntingBehavior : MonoBehaviour
{
    public GameObject search1, search2, search3;
    Vector3 destination;
    public float speed = 15, step;

    // Start is called before the first frame update
    void Start()
    {
        step = speed * Time.deltaTime;
        Patrol();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == destination)
            Patrol();

        transform.position = Vector3.MoveTowards(transform.position, destination, step);
        transform.LookAt(destination, Vector3.up);
    }

    int ChooseSearch()
    {
        return Random.Range(0, 3);
    }

    void Patrol()
    {
        int loc = ChooseSearch();

        switch (loc)
        {
            case 0:
                destination = search1.transform.position;
                break;
            case 1:
                destination = search2.transform.position;
                break;
            case 2:
                destination = search3.transform.position;
                break;
        }
    }
}

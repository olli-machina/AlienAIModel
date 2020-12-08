using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbiliyTriggers : MonoBehaviour
{
    GameManager manager;
    public int index;
    public int counter = 0;
    public float timer = 1.0f;
    public bool count = false;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (count)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f)
            {
                Debug.Log("Up");
                counter++;
                count = false;
                timer = 1f;
                if (counter >= 2)
                    manager.Abilities(index);
            }
        }
        else
            timer = 1.0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Touch");
            count = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player") //reset timer when they leave the area
        {
            count = false;
            timer = 1.0f;
        }
    }
}

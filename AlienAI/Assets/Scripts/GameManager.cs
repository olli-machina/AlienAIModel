using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(!player)
        {
            GameObject newPlayer = Instantiate(playerPrefab);
            newPlayer.transform.position = new Vector3(-17.56f, 2.51f, -4.09f);
            newPlayer.name = "Player";
            player = newPlayer;
        }
    }
}

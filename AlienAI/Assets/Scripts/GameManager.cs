using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    GameObject player;
    public GameObject[] abilityTriggers;
    public Image[] abilityIcons;
    Pathfinding pathfinding;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        pathfinding = GameObject.Find("Hunter").GetComponent<Pathfinding>();
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

    public void Abilities(int index)
    {
        switch(index)
        {
            case 0: case 1: case 2: case 3: case 4: case 5:
                pathfinding.moreLikely(index);
                break;
            
            case 6:
                pathfinding.FleeAbility();
                break;
            //case 7:
            //    BackAbility();
            //    break;
        }
        abilityIcons[index].color = Color.green;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //reference to our gameObject
    public GameObject obstaclePrefab;

    //
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    //variables to be usd with Invoke repeating method. 
    private float startDelay = 2;
    private float repeatRate = 2;

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //Invoke repeating is a method that allows you constantly call SpawnObstacle methoth.
        // with a delay and repeat variable. 
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Custome method for spawning the obstacle
    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
        
    }
}

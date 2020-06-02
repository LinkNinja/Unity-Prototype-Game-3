using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class MoveLeft : MonoBehaviour
{
    //create a variable to control the speed of the objects moving left
    private float speed = 30;

    //Create a variable that holds a referance to the class 
    private PlayerController playerControllerScript;

    private float leftBound = -15;


    // Start is called before the first frame update
    void Start()
    {
        //Setting this to the player controller script on our player
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        
    }
}

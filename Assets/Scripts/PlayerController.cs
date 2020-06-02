using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    //This is a new private variable that is the players Rigid body component. 
    private Rigidbody playerRb;

    //Variable to hold the animator component of the object
    private Animator playerAnim;
    //This is the audio that plays from the player
    private AudioSource playerAudio;

    //Create a variable tfrom the ParticleSystem class to assign it something in the editor.
    public ParticleSystem explosionParticle;
    //Create a variable for the particle sysem to assign it the dirt particle effect
    public ParticleSystem dirtParticle;


    // create a variable for an audio clip class for jump sound
    public AudioClip jumpSound;
    // create a second variable for an audio clip class for the crash sound.
    public AudioClip crashSound;



    //create a variable to apply jumpForce
    public float jumpForce = 10;

    //Create variable for gravity modifier
    public float gravityModifier;

    //Variable to check if the player is on the ground.
    public bool isOnGround = true;

    //Variable to check if the game is over.
    public bool gameOver;
    

    void Start()
    {
        //Here we are assigning the playerRb variable to this objects Rigid body component using GetComponent<Rigidbody>();
        playerRb = GetComponent<Rigidbody>();

        //Physics.gravity = Physics.gravity * gravityModifier;
        //changes how much gravity is in our game.
        Physics.gravity *= gravityModifier;

        //Set the variable to get the component of the object
        playerAnim = GetComponent<Animator>();

        playerAudio = GetComponent<AudioSource>();

        



    }

    // Update is called once per frame
    void Update()
    {

        //If space bar is pressed apply force to this players Rigidbody
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            //Force is now applied to the players rigid body using AddForce(); // YOU ARE ABLE TO APPLY FORCE MODE USING DIFFERENT FORCE MODE
            //ForceMode.NormalForce
            //
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;

            //playerAnim variable is assigned Jump Trig when the space key is pressed. and the character is on the ground.
            playerAnim.SetTrigger("Jump_trig");

            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound,1.0f);



        }
    }

    //Checks if the player collider is colliding with something. If it does then it switches isOnGround true
    private void OnCollisionEnter(Collision collision)
    {
        

        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("GameOver");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound,1.0f);


       
        }

    }
}

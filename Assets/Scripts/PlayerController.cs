using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;

    private Rigidbody2D playerRb;
    private float horizontalInput;
    private bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Get the player input here
        horizontalInput = Input.GetAxis("Horizontal");
        Flip(horizontalInput);
    }

    //All physics calculation should be done in the FixedUpdate
    private void FixedUpdate()
    {
        //Move the player through physics here
        float horizontalMovement = horizontalInput * moveSpeed;
        //Change the velocity in x by the input
        //We will leave the y velocity as is
        playerRb.velocity = new Vector2(horizontalMovement, 
            playerRb.velocity.y);
    }

    private void Flip(float movement)
    {
        //Check if we need to flip our character
        //Scenario 1: Is the input positive and is our player facing left?
        //Scenario 2: Is the input negative and our player is facing right?
        if(movement > 0 && !isFacingRight || movement < 0 && isFacingRight) 
        {
            //toggle the boolean
            isFacingRight = !isFacingRight;
            //chang the x scale of our player
            transform.localScale = new Vector3(transform.localScale.x * -1.0f,
                transform.localScale.y, transform.localScale.z);
        }
    }
}

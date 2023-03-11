using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private float moveSpeed = 5.0f;
    [SerializeField]
    private float jumpForce = 250f;

    [Header("Ground Check")]
    // What objects are considered as a ground? Make sure to change their layers
    [SerializeField] private LayerMask groundLayers;
    // Where is the player's feet/ground transform?
    [SerializeField] private Transform groundPoint;
    // How big is the radius of our ground checker
    [SerializeField] private float groundRadius = 0.2f;

    private Rigidbody2D playerRb;
    private float horizontalInput;
    private bool isFacingRight = true;
    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Get the player input here
        horizontalInput = Input.GetAxis("Horizontal");

        //Check if the player should jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }
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

        //Make the player jump by adding a force
        if (isJumping && IsGrounded())
        {
            playerRb.AddForce(new Vector2(0, jumpForce));
            isJumping = false;
        }
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

    /// <summary>
    /// This function will return true if our feet is touching the ground
    /// </summary>
    /// <returns></returns>
    private bool IsGrounded()
    {
        // Cast a circle on the groundPoint. Store any Colliders that we hit with the circle
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundPoint.position, groundRadius, groundLayers);
        for(int i = 0; i < colliders.Length; i++)
        {
            //Make sure that the gameobject we are colliding is not our own
            if(colliders[i].gameObject != this.gameObject)
            {
                return true;
            }
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundPoint.position, groundRadius);
    }
}

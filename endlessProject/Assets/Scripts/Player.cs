using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float jumpHeight;
    private Rigidbody2D playerRigidBody;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

	// Use this for initialization
	void Start ()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Movement();
	}

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);  
    }

    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpHeight);
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerRigidBody.velocity = new Vector2(-movementSpeed, playerRigidBody.velocity.y);
        }

        if (Input.GetKey(KeyCode.D))
        { 
            playerRigidBody.velocity = new Vector2(movementSpeed, playerRigidBody.velocity.y);
        }
    }
}

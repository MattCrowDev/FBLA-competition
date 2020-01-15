using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimberMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public float moveSpeed = 30f;
    public float jumpSpeed = 1f;
    

    float horizontalMove = 0f;
    bool jump = false;
    bool wallJump;


    bool forwardDash = false;
    bool backwardDash = false;





    Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed ;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (wallJump == true)
        {
            rb.velocity = transform.up  * jumpSpeed;
            Debug.Log("climbing wall");
        }

        //wall dash

        if(forwardDash == true && Input.GetButtonDown("Jump"))
        {
            rb.velocity = transform.right * -70f;

            Debug.Log("Dash");
            forwardDash = false;
            
        }

        if (backwardDash == true && Input.GetButtonDown("Jump"))
        {
            rb.velocity = transform.right * 70f;
            

            Debug.Log("Dash");
            backwardDash = false;
        }

    }
    private void FixedUpdate()
    {
        //move our character
        controller.Move(horizontalMove *Time.fixedDeltaTime, false, jump);

        jump = false;

    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("ClimbWallF"))
        {
            wallJump = true;
            forwardDash = true;
            backwardDash = false;
        }
        if (col.gameObject.tag.Equals("ClimbWallB"))
        {
            wallJump = true;
            backwardDash = true;
            forwardDash = true;
        }
        if (col.gameObject.tag.Equals("noJump"))
        {
            backwardDash = false;
            forwardDash = false;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("ClimbWallF"))
            wallJump = false;
        if (col.gameObject.tag.Equals("ClimbWallB"))
            wallJump = false;

    }
}

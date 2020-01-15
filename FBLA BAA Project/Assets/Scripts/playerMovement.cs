using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public float moveSpeed = 30f;
    public float jumpSpeed = 1f;
    public float BSpeed = 70f;

    float horizontalMove = 0f;
    float dashMove;
    bool jump = false;
    bool wallJump;

    bool dashUse = true;


   
  

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


        if(dashUse == false && Input.GetButtonDown("Fire1"))
        {
            rb.velocity = transform.right * BSpeed;

            Debug.Log("Dash");
            dashUse = true;
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
        if (col.gameObject.tag.Equals("climbWall"))
        {
            wallJump = true;
            dashUse = false;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("climbWall"))
            wallJump = false;
            
    }
}

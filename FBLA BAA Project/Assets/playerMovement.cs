﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public float runSpeed = 30f;

    float horizontalMove = 0f;
    bool jump = false;

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed ;

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

    }
    private void FixedUpdate()
    {
        //move our character
        controller.Move(horizontalMove *Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}

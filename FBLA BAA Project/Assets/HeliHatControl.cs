﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliHatControl : MonoBehaviour
{

    public Vector2 Speed = new Vector2(5, 2);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float InputX = Input.GetAxis("Horizontal");
        float InputY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(Speed.x * InputX, Speed.y * InputY , 0);
        movement *= Time.deltaTime;


        transform.Translate(movement);

    }
    void OnCollisionEnter2D(Collision2D col)
    {
       
    }

}



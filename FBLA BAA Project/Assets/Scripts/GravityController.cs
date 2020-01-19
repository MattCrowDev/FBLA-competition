using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GravityController : MonoBehaviour
{
    bool move = false;
   



    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        var velocity = rb.velocity;
        Debug.Log(velocity);

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (rb.velocity.sqrMagnitude < 0.001f)
        {  //Or some other value
            move = true;
            Debug.Log("The ship is still");
          

        }
         if (rb.velocity.sqrMagnitude > 0.001f)
        {  //Or some other value
            move = false;
            Debug.Log("in motion");

        }

        if (move == true && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Physics2D.gravity = new Vector2(-9.81f, 0f);
            


        }
        else if (move == true && Input.GetKeyDown(KeyCode.DownArrow))
        {
            Physics2D.gravity = new Vector2(0f, -9.81f);
        }
        else if (move == true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Physics2D.gravity = new Vector2(0f, 9.81f);
        }
        else if (move == true && Input.GetKeyDown(KeyCode.RightArrow))
        {
            Physics2D.gravity = new Vector2(9.81f, 0f);
        }

    }
}

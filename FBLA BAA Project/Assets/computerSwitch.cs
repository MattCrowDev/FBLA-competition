using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class computerSwitch : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("ComputerGuy"))
        {
            Debug.Log("Hitting");
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Hitting");
        }
    }
}

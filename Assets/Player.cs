using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movespeed;
    public float jumpforce;
    private float xInput;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
            xInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2 (xInput * movespeed, rb.velocity.y);
          
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
       
    }
}

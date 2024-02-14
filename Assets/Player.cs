using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float movespeed;
    [SerializeField] private float jumpforce;
   
    
    private float xInput;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private float movespeed;
    [SerializeField] private float jumpforce;

    private float xInput;

    private int facingDir = 1;
    private bool facingRight = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {

        Movement();

        CheckInput();

        if(Input.GetKeyDown(KeyCode.R))
            Flip();

        FlipController();
        AnimatorControllers();

    }

    private void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Movement()
    {
        rb.velocity = new Vector2(xInput * movespeed, rb.velocity.y);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpforce);
    }

    private void AnimatorControllers()
    {
       bool isMoving = rb.velocity.x != 0;

        anim.SetBool("isMoving", isMoving);

    }

    private void Flip() 
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);

    }

    private void FlipController()
    {
        if (rb.velocity.x ! > 0 && !facingRight) 
        {
            Flip();
        }
        else if (rb.velocity.x < 0 && facingRight)
        {
            Flip();
        }
    }
}

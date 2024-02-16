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


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {

        Movement();

        CheckInput();

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
}

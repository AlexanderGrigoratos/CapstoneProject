using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Animator anim;

    [Header("Collision info")]
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected LayerMask whatIsGround;

    protected bool isGrounded;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

    }

    
    protected virtual void Update()
    {
        CollisionChecks();
    }


    protected virtual private void CollisionChecks()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    }
}

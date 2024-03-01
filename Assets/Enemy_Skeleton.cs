using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Skeleton : Entity
{
    bool isAttacking;

    [Header("Movement info")]
    [SerializeField] private float moveSpeed;

    [Header("Player Detection")]
    [SerializeField] private float playerCheckDistance;
    [SerializeField] private LayerMask whatIsPlayer;

    private RaycastHit2D isPlayerDetected;


    protected override void Start()
    {
        base.Start();

        
    }

    protected override void Update()
    {
        base.Update();

        if(isPlayerDetected.distance > 1)
        {
            rb.velocity = new Vector2(moveSpeed * 1.5f* facingDir, rb.velocity.y);

            Debug.Log("I see the player");
        }
        else
        {
            Debug.Log("ATTACK!" + isPlayerDetected);
        }

        if (!isGrounded || isWallDetected)
            Flip();

        rb.velocity = new Vector2 (moveSpeed * facingDir , rb.velocity.y);
    }

    protected override void CollisionChecks()
    {
        base.CollisionChecks();

        isPlayerDetected = Physics2D.Raycast(transform.position, Vector2.right, playerCheckDistance * facingDir, whatIsPlayer);


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Skeleton : Entity
{
    [Header("Movement info")]
    [SerializeField] private float moveSpeed;


    protected override void Start()
    {
        base.Start();

        
    }

    protected override void Update()
    {
        base.Update();

        if (!isGrounded || isWallDetected)
            Flip();

        rb.velocity = new Vector2 (moveSpeed * facingDir , rb.velocity.y);
    }
}

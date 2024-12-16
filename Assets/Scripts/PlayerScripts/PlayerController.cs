using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody2D rigidBody;
    private Collider2D playerCollider;
    public LayerMask groundLayer;

    [Header("Movement")]
    private Vector2 direction;
    public float movementSpeed = 9f;
    public float acceleration = 7f;
    public float decceleration = 9f;
    public float velPower = 1.2f;

    [Header("Jumping")]
    public float jumpForce = 12f;
    private bool isGrounded = false;
    private bool canDoubleJump = true;
    private bool isJumping = false;
    private float lastGroundedTime;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        // Coyote Timer
        lastGroundedTime -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Move();
        IsGrounded();
    }
    public float GetVelocityX()
    {
        return rigidBody.velocity.x;
    }
    public bool GetIsGrounded()
    {
        return isGrounded;
    }
    private void Move()
    {
        float targetSpeed = direction.x * movementSpeed;
        float speedDif = targetSpeed - rigidBody.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);

        rigidBody.AddForce(movement * Vector2.right, ForceMode2D.Force);
    }

    private void Jump()
    {
        rigidBody.velocity = new Vector2(direction.x ,0f);
        rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        lastGroundedTime = 0;
        isJumping = true;
    }

    private void IsGrounded()
    {
        Vector2 boxCastOrigin = new Vector2(playerCollider.bounds.center.x, playerCollider.bounds.min.y);
        Vector2 boxCastSize = new Vector2(playerCollider.bounds.size.x, 0.02f);

        RaycastHit2D groundHit = Physics2D.BoxCast(boxCastOrigin, boxCastSize, 0f, Vector2.down, 0.02f, groundLayer);

        if (groundHit.collider != null)
        {
            isGrounded = true;
            canDoubleJump = true;
            isJumping = false;
            lastGroundedTime = 0.15f;
        }
        else
        {
            isGrounded = false;
        }
        FallGravity();
    }

    private void FallGravity()
    {
        if (rigidBody.velocity.y < 0)
        {
            rigidBody.gravityScale = 2f;
        }
        else
        {
            rigidBody.gravityScale = 1.1f;
        }
    }

    public void HandleMoveInput(InputAction.CallbackContext ctx)
    {
        direction = ctx.ReadValue<Vector2>();
    }

    public void HandleJumpInput(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && lastGroundedTime > 0 && !isJumping)
        {
            Jump();
        }
        else if (ctx.performed && !isGrounded && canDoubleJump)
        {
            Jump();
            canDoubleJump = false;
        }

        // Jump Cut
        if (ctx.canceled && rigidBody.velocity.y >= 0)
        {
            rigidBody.AddForce(Vector2.down * rigidBody.velocity.y * (1 - 0.1f), ForceMode2D.Impulse);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
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
    public float movementSpeed;
    public float maxSpeed = 6f;
    public float accelerationSpeed = 25f;

    [Header("Jumping")]
    private bool isGrounded = false;
    private bool canDoubleJump = true;
    public float jumpForce = 500f;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        Move();
        IsGrounded();
    }

    private void Move()
    {
        if (direction != Vector2.zero && movementSpeed < maxSpeed)
        {
            movementSpeed += Time.deltaTime * accelerationSpeed;
        }
        if (direction == Vector2.zero)
        {
            movementSpeed = 0f;
        }
        rigidBody.velocity = (new Vector2(direction.x * movementSpeed, rigidBody.velocity.y));
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
        }
        else
        {
            isGrounded = false;
        }
    }

    public void HandleMoveInput(InputAction.CallbackContext ctx)
    {
        direction = ctx.ReadValue<Vector2>();
    }

    public void HandleJumpInput(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && isGrounded)
        {
            rigidBody.velocity = new Vector2(direction.x, 0);
            rigidBody.AddForce(new Vector2(0, jumpForce));
        }
        else if (ctx.performed && !isGrounded && canDoubleJump)
        {
            rigidBody.velocity = new Vector2(direction.x, 0);
            rigidBody.AddForce(new Vector2(0, jumpForce));
            canDoubleJump = false;
        }
        if (ctx.canceled && rigidBody.velocity.y >= 0)
        {
            rigidBody.velocity = new Vector2(direction.x, 0);
        }
    }
}

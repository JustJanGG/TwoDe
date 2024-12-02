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
    private bool isGrounded = false;
    private Vector2 direction;
    private bool canDoubleJump = true;
    public float movementSpeed = 5f;
    public float jumpForce = 500f;

    // Start is called before the first frame update
    void Start()
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
        rigidBody.velocity = (new Vector2(direction.x * movementSpeed, rigidBody.velocity.y));
    }

    private void IsGrounded()
    {
        Vector2 boxCastOrigin = new Vector2(playerCollider.bounds.center.x, playerCollider.bounds.min.y);
        Vector2 boxCastSize = new Vector2(playerCollider.bounds.size.x, 0.02f);

        RaycastHit2D groundHit = Physics2D.BoxCast(boxCastOrigin, boxCastSize, 0f, Vector2.down, 0.02f, groundLayer);
        
        if (groundHit.collider != null)
        {
            isGrounded =  true;
            canDoubleJump = true;
        }
        else 
        {
            isGrounded =  false; 
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
            rigidBody.velocity = new Vector2(direction.x ,0);
            rigidBody.AddForce(new Vector2(0, jumpForce));
        } 
        else if (ctx.performed && !isGrounded && canDoubleJump) 
        {
            rigidBody.velocity = new Vector2(direction.x, 0);
            rigidBody.AddForce(new Vector2(0, jumpForce));
            canDoubleJump = false;
        }
    }
}

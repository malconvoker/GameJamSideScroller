using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 10.0f;
    public int maxJumps = 2; // Adjust the number of jumps allowed.

    private Rigidbody2D rb;
    private int jumpsRemaining;
    private bool isGrounded = true;

    private Animator anim;
    private float dirX = 0f;

    SpriteRenderer rbSprite;

    private enum MovementState
    {
        Idle,
        Walking,
        Jumping,
        Falling
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsRemaining = maxJumps;
        rbSprite = GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        dirX = Input.GetAxisRaw("Horizontal");
        if (horizontalInput < 0)
        {
            rbSprite.flipX = true;
        }
        else
        {
            rbSprite.flipX = false;
        }

        Vector3 movement = new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        if (Input.GetButtonDown("Jump") && jumpsRemaining > 0)
        {
            Jump();
        }

        UpdateAnimationStatus();

    }

    private void UpdateAnimationStatus()
    {

        MovementState state;

        if (dirX > 0)
        {
            state = MovementState.Walking;
        }
        else if (dirX < 0)
        {
            state = MovementState.Walking;
        }
        else
        {
            state = MovementState.Idle;
        }

            if (rb.velocity.y > 0.1f)
            {
                state = MovementState.Jumping;
            }
            else if (rb.velocity.y < -0.1f)
            {
                state = MovementState.Falling;
            }
            anim.SetInteger("state", (int)state);


        }
        void Jump()
        {
            rb.velocity = new Vector2(rb.velocity.x, 0); // Zero out the vertical velocity before jumping.
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpsRemaining--;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                jumpsRemaining = maxJumps;

            }
        }


    } 


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
    public bool facingRight = true;

    SpriteRenderer rbSprite;
   

    private enum MovementState
    {
        Idle,
        Walking,
        Jumping,
        Falling,
        Attack
    }
    private MovementState state;

    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsRemaining = maxJumps;
        rbSprite = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        dirX = Input.GetAxisRaw("Horizontal");
        if (horizontalInput < 0)
        {
            facingRight = false;
        }
        else if (horizontalInput > 0)
        {
            facingRight = true;
        }

        if (facingRight)
        {
            rbSprite.flipX = false;
        }
        else
        {
            rbSprite.flipX = true;
        }

        Vector3 movement = new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        if (Input.GetButtonDown("Jump") && jumpsRemaining > 0 && isGrounded)
        {
            Jump();
            audioSource.Play();
        }

        if (IsGrounded() && rb.velocity.y <= 0) // Check if the player is grounded and not rising from a jump.
        {
            jumpsRemaining = maxJumps;
        }
        UpdateAnimationStatus();

    }

    private void UpdateAnimationStatus()
    {

        

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
         


        if (Input.GetButtonDown("Fire1"))
        {
            state = MovementState.Attack;

            // Trigger the attack animation.
            anim.SetTrigger("Attack");
        }
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

   

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, groundLayerMask);
    }

} 


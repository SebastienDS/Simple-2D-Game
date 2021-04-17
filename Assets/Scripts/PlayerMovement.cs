using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public bool isJumping;
    public bool isGrounded;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;


    private void FixedUpdate()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        MovePlayer(horizontalMovement);
        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("speed", characterVelocity);
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
        }
    }

    void MovePlayer(float horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f);

        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    void Flip(float velocity)
    {
        if (velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        } else if (velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}

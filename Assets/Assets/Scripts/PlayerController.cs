using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    private float originalWalkSpeed;
    private float originalRunSpeed;
    public float jumpForce = 10f;
    public float jumpAnimationDelay = 0.5f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.2f;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private bool isRunning;
    private bool isFacingRight = true;
    private bool canMove = false;
    private bool isNearBush = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        originalWalkSpeed = walkSpeed;
        originalRunSpeed = runSpeed;
        StartCoroutine(StartMovementAfterDelay(3f));
    }

    void Update()
    {
        if (!canMove)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("IsWalking", false);
            return;
        }

        float moveDirection = 1.0f;
        isRunning = Input.GetKey(KeyCode.LeftShift);

        float speed = isRunning ? runSpeed : walkSpeed;

        if (isNearBush)
        {
            speed *= 0.5f;
        }

        Vector2 movement = new Vector2(moveDirection * speed, rb.velocity.y);
        rb.velocity = movement;

        if (!isFacingRight)
        {
            Flip();
        }

        if (moveDirection != 0)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            StartCoroutine(DelayedJumpAnimation());
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        animator.SetBool("IsRunning", isRunning);
        animator.SetBool("IsGrounded", isGrounded);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    IEnumerator DelayedJumpAnimation()
    {
        animator.SetBool("IsJumping", true);
        yield return new WaitForSeconds(jumpAnimationDelay);
        animator.SetBool("IsJumping", false);
    }

    IEnumerator StartMovementAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canMove = true;
    }

    public void ApplySlowEffect(float slowMultiplier)
    {
        isNearBush = true;
        originalWalkSpeed = walkSpeed;
        originalRunSpeed = runSpeed;
        walkSpeed *= slowMultiplier;
        runSpeed *= slowMultiplier;
    }

    public void RemoveSlowEffect()
    {
        isNearBush = false;
        walkSpeed = originalWalkSpeed;
        runSpeed = originalRunSpeed;
    }
    public void Jump()
    {
        if (isGrounded)
        {
            StartCoroutine(DelayedJumpAnimation());
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}


using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public float jumpForce = 3f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private bool isGrounded;
    private bool jumpRequest; // NEW
    private Rigidbody2D rb;
    private Vector3 startPosition;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPosition = transform.position;
    }

    void Update()
    {
        // Handle input here
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpRequest = true;
        }
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f));
        SpriteFlip(horizontalInput);

        if (horizontalInput != 0) PlayWalk();

        if (jumpRequest)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0); // Optional: cancel downward force
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            PlayJump();
            jumpRequest = false; // Reset jump
        }
    }

    private void SpriteFlip(float horizontalInput)
    {
        spriteRenderer.flipX = horizontalInput < 0;
    }

    #region AnimationHandler
    private void PlayWalk()
    {
        animator.SetTrigger("goWalk");
    }

    private void PlayJump()
    {
        animator.SetTrigger("goJump");
    }
    #endregion

    public void ResetToStart()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        transform.position = startPosition;
        rb.WakeUp();
    }
}

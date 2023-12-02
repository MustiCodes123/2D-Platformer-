using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 0f;
    public float gravityScale = 3f;

    public PhysicsMaterial2D bouncyMat, normalMat;

    private Rigidbody2D rb;
    public bool isGrounded;
    private bool canJump = true;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private float groundCheckRadius = 0.3f;

    public Animator anim;
    [SerializeField] SpriteRenderer mySpriteRenderer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        if (moveInput > 0)
            mySpriteRenderer.flipX = false;
        else if (moveInput < 0)
            mySpriteRenderer.flipX = true; 

        if (isGrounded)
            anim.SetBool("Grounded", true);
        else
            anim.SetBool("Grounded", false);

        // Check if the player is grounded, if yes, then it can jump, else, jump is disabled
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (!isGrounded && jumpForce >=0)
            rb.sharedMaterial = bouncyMat;
        else
            rb.sharedMaterial = normalMat;

        // Horizontal movement
        if (jumpForce == 0.0f && isGrounded)
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }

        // Jumping
        if (Input.GetButton("Jump") && isGrounded && canJump)
        {
            jumpForce += 0.09f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded && canJump)
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }

        if (jumpForce >= 15f && isGrounded)
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, jumpForce);
            Invoke("ResetJump", 0.2f);
        }

        if (Input.GetButtonUp("Jump"))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(moveInput * moveSpeed, jumpForce);
                jumpForce = 0.0f;
            }
            canJump = true;
        }

    }

    void ResetJump()
    {
        jumpForce = 0.0f;
        canJump = false;
    }
}
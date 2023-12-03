using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 0f;
    public float gravityScale = 3f;
    public bool isGrounded = true;
    private bool isHolding = false;

    public PhysicsMaterial2D bouncyMat, normalMat;

    private Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private float groundCheckRadius = 0.2f;
        
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
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        RotateHoriz(moveInput);
        SetSpriteVals();
        SetMat();
        JumpChar(moveInput);
        MoveChar(moveInput);
    }

    void JumpChar(float moveInput)
    {
        if (Input.GetButton("Jump") && isGrounded)
        {
            jumpForce += 0.07f;
            isHolding = true;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }

        if (jumpForce >= 13.5f && isGrounded)
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, jumpForce);
            Invoke("ResetJump", 0.2f);
        }

        if (Input.GetButtonUp("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, jumpForce);
            jumpForce = 0.0f; 
            isHolding = false;
        }
    }

    void ResetJump()
    {
        jumpForce = 0.0f;
        isHolding = false;
    }
    void MoveChar(float moveInput)
    {
        if (isGrounded && jumpForce == 0.0f) 
        {
            if (moveInput != 0.0f)
            {
                rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            }
        }
    }

    void RotateHoriz(float moveInput)
    {
        if (moveInput > 0)
            mySpriteRenderer.flipX = false;
        else if (moveInput < 0)
            mySpriteRenderer.flipX = true;
    }
    void SetSpriteVals()
    {
        anim.SetBool("Grounded", isGrounded);
        anim.SetBool("isWalking", Mathf.Abs(rb.velocity.x) > 1);
        anim.SetBool("isFalling", rb.velocity.y <= -1);
        anim.SetBool("isHolding", isHolding);
    }
    void SetMat()
    {
        if (rb.velocity.y <= -1)
            rb.sharedMaterial = normalMat;
        else if (rb.velocity.y > 1)
            rb.sharedMaterial = bouncyMat;
    }

}
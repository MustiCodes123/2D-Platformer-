using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 0f;
    public float gravityScale = 3f;
    public bool isGrounded = true;
    private bool isHolding = false;

    public PhysicsMaterial2D bouncyMat, normalMat;

    public Rigidbody2D rb;
    public Transform groundCheck;

    public Transform gameManager;

    public LayerMask groundLayer;

    private float groundCheckRadius = 0.2f;

    public Animator anim;

    public AudioClip jumpSound;
    public AudioSource jumpSoundSource;



    [SerializeField] SpriteRenderer mySpriteRenderer;

    public AudioClip hitSound;

    public AudioSource hitAudioSource;

    private void playHitSound()
    {
        // Check if an AudioListener is present in the scene
        AudioListener audioListener = FindObjectOfType<AudioListener>();
        if (audioListener == null)
        {
            Debug.LogWarning("No AudioListener found in the scene. Adding a default AudioListener.");
            Camera.main.gameObject.AddComponent<AudioListener>();
        }

        // Play the audio in a loop

        hitAudioSource.Play();
    }

    // Update is called once per frame

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject && !isGrounded)
            playHitSound();

    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
        jumpSoundSource = gameObject.GetComponent<AudioSource>();
        jumpSoundSource.clip = jumpSound;
        hitAudioSource = gameObject.AddComponent<AudioSource>();
        hitAudioSource.clip = hitSound;
        Time.timeScale = 1f;
    }



    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            gameManager.position.Set(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);   
        }

        RotateHoriz(moveInput);
        SetSpriteVals();
        SetMat();
        JumpChar(moveInput);
        MoveChar(moveInput);
    }

    void playJumpSound()
    {

        AudioListener audioListener = FindObjectOfType<AudioListener>();
        if (audioListener == null)
        {
            Debug.LogWarning("No AudioListener found in the scene. Adding a default AudioListener.");
            Camera.main.gameObject.AddComponent<AudioListener>();
        }



        jumpSoundSource.Play();
    }
    void JumpChar(float moveInput)
    {
        if (Input.GetButton("Jump") && isGrounded)
        {
            jumpForce += 0.175f;
            isHolding = true;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y);


        }

        if (jumpForce >= 14.5f && isGrounded)
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, jumpForce);
            Invoke("ResetJump", 0.2f);

            playJumpSound();

        }

        if (Input.GetButtonUp("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, jumpForce);
            jumpForce = 0.0f;
            isHolding = false;

            playJumpSound();
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
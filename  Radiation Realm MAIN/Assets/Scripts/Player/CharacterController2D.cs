using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CharacterController2D : MonoBehaviour
{
    [Header("Object Reference")]
    public Camera mainCamera;  // Reference to the main camera
    public Animator myAnim;
    private Vector2 mousePositionRelativeToPlayer;  // To store the mouse position relative to the player
    private Rigidbody2D rb;

    [Header("Vertical Movement")]
    public float moveSpeed = 5f;        // Character movement speed
    public float walkSpeed = 2.5f;
    float movementInput;

    [Header("Horizontal Movement")]
    public float jumpForce = 10f;       // Jump force
    public int extraJump = 1;
    public float extraJumpTime = 0.2f;
    public float customGravity;
    int jumpCount = 0;
    float jumpCooldown;
    bool isGravityInverted = false;
    public AudioClip jumpSound;


    [Header("Ground Check")]
    public LayerMask groundLayer;       // LayerMask to specify which objects are considered ground
    public Transform feet;
    bool isGrounded;            // Flag to check if the character is grounded



    [Header("Sound")]

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;

    [Header("Wall Jump")]
    public float wallJumpTime = 0.2f;
    public float wallSlideSpeed = 0.3f;
    public float wallDistance = 0.5f;
    bool isWallSliding = false;
    RaycastHit2D wallCheckHit;
    float jumpTime;


    bool isFacingRight = true;




    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") || isWallSliding && Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        CheckGrounded();

        if (Input.GetKeyDown(KeyCode.G))
        {
            isGravityInverted = !isGravityInverted;
        }
    }


    private void FixedUpdate()
    {
        // Calculate the mouse position relative to the player
        mousePositionRelativeToPlayer = mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;


        movementInput = Input.GetAxisRaw("Horizontal");

        // Check if Ctrl key is held down to enable walking
        bool isWalking = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);

        float currentMoveSpeed = isWalking ? walkSpeed : moveSpeed;

        // Running Animation
        if (Mathf.Abs(movementInput)  > 0)
        {
            myAnim.SetBool("isRunning", true);
        }
        else
        {
            myAnim.SetBool("isRunning", false);
        }

        // Check if gravity is inverted
        if (isGravityInverted)
        {
            // Reverse the character's horizontal movement
            rb.velocity = new Vector2(-movementInput * moveSpeed * Time.deltaTime, rb.velocity.y);

            // Invert the character's horizontal movement
            //movementInput *= -1;

            // Invert the gravity scale to apply reverse gravity
            rb.gravityScale = -customGravity;


            transform.localScale = new Vector3(transform.localScale.x, -1f, 1f);


            // Flip the player sprite based on the mouse position
            if (mousePositionRelativeToPlayer.x < 0)
            {
                transform.localScale = new Vector3(-1f, -1f, 1f);
            }
            else
            {
                transform.localScale = new Vector3(1f, -1f, 1f);
            }
        }
        else
        {
            // Normal horizontal movement
            rb.velocity = new Vector2(movementInput * currentMoveSpeed * Time.deltaTime, rb.velocity.y);

            // Set the gravity scale to the custom gravity
            rb.gravityScale = customGravity;

            transform.localScale = new Vector3(transform.localScale.x, 1f, 1f);


            // Flip the player sprite based on the mouse position
            if (mousePositionRelativeToPlayer.x < 0)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                isFacingRight = false;
            }
            else
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                isFacingRight = true;
            }
        }


        if (movementInput < 0)
        {
            transform.localScale = new Vector3(-1f, transform.localScale.y, 1f);
            isFacingRight = false;
        }
        else if (movementInput > 0) // Flip back if moving right (positive input)
        {
            transform.localScale = new Vector3(1f, transform.localScale.y, 1f);
            isFacingRight = true;
        }

        rb.velocity = new Vector2(movementInput * moveSpeed * Time.deltaTime, rb.velocity.y);

        /*
        // Wall Jump
        if (isFacingRight)
        {
            wallCheckHit = Physics2D.Raycast(transform.position, new Vector2(wallDistance, 0), wallDistance, groundLayer);
            Debug.DrawRay(transform.position, new Vector2(wallDistance, 0), Color.blue);
        }
        else
        {
            wallCheckHit = Physics2D.Raycast(transform.position, new Vector2(-wallDistance, 0), wallDistance, groundLayer);
            Debug.DrawRay(transform.position, new Vector2(-wallDistance, 0), Color.blue);
        }

        if(wallCheckHit && !isGrounded && movementInput != 0)
        {
            isWallSliding = true;
            jumpTime = Time.time + wallJumpTime;
        }
        else if(jumpTime < Time.time)
        {
            isWallSliding = false;
        }

        if (isWallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, wallSlideSpeed, float.MinValue));
        }
        */




    }

    void Jump()
    {
        if (isGravityInverted)
        {
            if (isGrounded || jumpCount < extraJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, -jumpForce * Time.deltaTime);
                audioSource.PlayOneShot(jumpSound);
                jumpCount++;
                myAnim.SetTrigger("isJumping");
            }

        }
        else
        {
            if (isGrounded || jumpCount < extraJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);
                jumpCount++;
                myAnim.SetTrigger("isJumping");
                audioSource.PlayOneShot(jumpSound);
            }

        } 
    }

    void CheckGrounded()
    {
        if (Physics2D.OverlapCircle(feet.position,0.5f, groundLayer))
        {
            isGrounded = true;
            jumpCount = 0;
            jumpCooldown = Time.time + extraJumpTime;
        }
        else if (Time.time < jumpCooldown)
        {
            isGrounded = true;

        }
        else
        {
            isGrounded = false;
        }
    }

    public void PlayRunningSFXOne()
    {
        audioSource.PlayOneShot(audioClips[0]);
    }
    public void PlayRunningSFXTwo()
    {
        audioSource.PlayOneShot(audioClips[1]);
    }
}

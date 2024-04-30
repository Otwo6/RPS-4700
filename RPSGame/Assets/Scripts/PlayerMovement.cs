using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;
    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;
    
    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    bool wasGrounded;
    public Transform orientation;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    public Rigidbody rb;
    [Header("Audio")]
    AudioManager audioManager;
    // Adjust this value to control the frequency of footstep sounds
    public float footstepInterval = 0.5f;
    private float footstepTimer;

    [Header("Cosmetics")]
    [SerializeField] GameObject character;
    [SerializeField] Animator animator;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
        wasGrounded = true; // Assuming the player starts on the ground
        footstepTimer = footstepInterval; // Initialize footstep timer
    }
    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);
        MyInput();
        SpeedControl();
        // Play landing sound when the player lands on the ground
        if (!wasGrounded && grounded)
        {
            audioManager.PlaySFX(audioManager.landing);
           
        }
        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
        wasGrounded = grounded;
        // Timer for footstep sounds
        if (grounded && (horizontalInput != 0 || verticalInput != 0))
        {
            footstepTimer -= Time.deltaTime;
            if (footstepTimer <= 0)
            {
                audioManager.PlaySFX(audioManager.footsteps);
                footstepTimer = footstepInterval;
            }
        }
        else
        {
            footstepTimer = 0; // Reset timer when not moving
        }
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
            audioManager.PlaySFX(audioManager.jumping);
			print("please");
        }
    }
    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        // set animation speed
        animator.SetFloat("Speed", rb.velocity.magnitude);
        // face character representation towards movement of direction
        if(moveDirection != Vector3.zero)
            character.transform.forward = moveDirection;
        // on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        // in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}


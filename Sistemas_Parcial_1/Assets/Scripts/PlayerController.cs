using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float inputX;
    private float inputY;

    private Animator animator;

    [Header("Movement")]
    [SerializeField] private float maxSpeed;
    [SerializeField] private float maxAcceleration;
    [SerializeField] private int jumpSpeed;
    [SerializeField] private int extraJumps;
    [SerializeField] private Transform feet;
    [SerializeField] private LayerMask groundLayer;
    private int groundFrames;
    private int jumpkeyFrames;

    private bool IsJumping;
    private bool Jumped;
    private Rigidbody2D rb;
    private int jumpCount;

    [Header("Combat")]
    [SerializeField] private int damage;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", Mathf.Abs(inputX));

        bool IsGrounded = false;

        groundFrames++;
        jumpkeyFrames++;
        
        if (rb.velocity.y <= 0f)
        {
            Collider2D ground = Physics2D.OverlapBox(feet.position, new Vector2(0.99f, 0.05f), 0f, groundLayer);
            IsGrounded = (ground != null);
        }
        

        if (IsGrounded)
        {
            jumpCount = extraJumps;
            groundFrames = 0;
            Jumped = false;
            animator.SetBool("Grounded", true);

            if (jumpkeyFrames < 3)
            {
                Jump();
            }
        }

        if (!IsGrounded)
        {
            animator.SetBool("Grounded", false);
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            jumpkeyFrames = 0;

            if (IsGrounded || (groundFrames < 3 && !Jumped))
            {
                Jump();
            }
           /* else
            {
                if (jumpCount > 0) 
                {
                    Jump();
                    jumpCount--;
                }
            } */        
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            if (rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f);
            }
            
        }
               
    }

    void FixedUpdate()
    {
       float desiredSpeed = inputX * maxSpeed;

       float diffSpeed = desiredSpeed - rb.velocity.x;

       diffSpeed = Mathf.Clamp(diffSpeed, -maxAcceleration, maxAcceleration);

       float Xforce = rb.mass * diffSpeed;

        if (inputX > 0.1f)
        {
            rb.AddForce(new Vector2(Xforce, 0f), ForceMode2D.Impulse);
            transform.rotation = (Quaternion.Euler(0, 0, 0));
        }     
        else if (inputX < -0.1f) 
        {
            rb.AddForce(new Vector2(Xforce, 0f), ForceMode2D.Impulse);
            transform.rotation = (Quaternion.Euler(0, 180, 0));
        }
    }


    private void Jump()
    {
        Jumped = true;
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        
    }


}

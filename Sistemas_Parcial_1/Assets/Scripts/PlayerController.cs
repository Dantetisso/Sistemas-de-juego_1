using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float xInput;
    private float YInput;

    [Header("Movement")]
    [SerializeField] private float maxSpeed;
    [SerializeField] private float maxAcceleration;
    [SerializeField] private int jumpSpeed;
    [SerializeField] private int extraJumps;
    [SerializeField] private Transform feet;
    [SerializeField] private LayerMask groundLayer;

    private bool IsJumping;
    private Rigidbody2D rb;
    private int jumpCount;

    [Header("Combat")]
    [SerializeField] private int damage;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
       
    }


    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        YInput = Input.GetAxisRaw("Vertical");

        Collider2D ground = Physics2D.OverlapBox(feet.position, new Vector2(0.99f, 0.05f), 0f, groundLayer);
        bool IsGrounded = (ground != null);
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (IsGrounded)
            {
                Jump();
            }
            else
            {
                if (jumpCount > 0) 
                {
                    Jump();
                    jumpCount--;
                }
            }         
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            if (rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
            
        }

        if (IsGrounded)
        {
            jumpCount = extraJumps;
        }
    }

    void FixedUpdate()
    {
       float desiredSpeed = xInput * maxSpeed;

       float diffSpeed = desiredSpeed - rb.velocity.x;

       diffSpeed = Mathf.Clamp(diffSpeed, -maxAcceleration, maxAcceleration);

       float Xforce = rb.mass * diffSpeed;

        if (xInput > 0.1f|| xInput < -0.1f)
        {
            rb.AddForce(new Vector2(Xforce, 0f), ForceMode2D.Impulse);
        }       
    }


    private void Jump()
    {        
        rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
    }


}

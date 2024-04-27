using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xInput;
    private float YInput;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float maxAcceleration;
    [SerializeField] private int jumpForce;
    [SerializeField] private int damage;
    [SerializeField] private Transform feet;
    [SerializeField] private LayerMask layer;
    private bool IsJumping;
    private Rigidbody2D rb;
   


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        YInput = Input.GetAxisRaw("Vertical");

        
        if (Input.GetKeyDown(KeyCode.W))
        {
            Collider2D ground = Physics2D.OverlapBox(feet.position, Vector2.one, 0f, layer);
            print(ground.gameObject.name);

            if (ground != null)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            
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

}

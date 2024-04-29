using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    #region Variables
    private float inputX;
    private float inputY;

    private Animator animator;

    [Header("Health")]
    [SerializeField] private int maxHealth;
    public int currentHealth;
    private bool IsDead;


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

    [Header("Interaction")]
    [SerializeField] private LayerMask interactableLayer;
    
    
    [Header("Combat")]
    [SerializeField] private int attackDamage;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayer;
    #endregion

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


        if (Input.GetKeyDown(KeyCode.UpArrow))
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

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ONInteract();
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


    #region Metodos
    private void Jump()
    {
        Jumped = true;
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D hit = Physics2D.OverlapBox(attackPoint.position, new Vector2(1f, 1f), 0f, enemyLayer);
        EnemyController enemy = hit.GetComponent<EnemyController>();

        if (enemy != null)
        {
            enemy.GetDamage(attackDamage);
            Debug.Log(hit);
        }
        
        Debug.Log(hit);
    }

    private void ONInteract()
    {
        Debug.Log("jiji");
        
        Collider2D[] colliders = Physics2D.OverlapBoxAll(attackPoint.position,new Vector2(1f, 1f), 0f, interactableLayer);

        foreach (Collider2D items in colliders)
        {
            if (items.TryGetComponent(out IInteractable interactable))
            {
                interactable.Interact();
                Debug.Log(colliders);
            }
        }      

    }

    public void UpdateHealth() 
    {
        maxHealth = currentHealth;
    }

    public void GetDamage(int damage) 
    {
        currentHealth -= damage;
    }
              
    public void Heal(int heal)
    {
        currentHealth += heal;

        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private int GetCurrentHealth()
    {
        return currentHealth;
    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }

    private void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    public void Death()
    {
        Debug.Log("died");
    }
    #endregion
}

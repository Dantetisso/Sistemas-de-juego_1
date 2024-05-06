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

    private Rigidbody2D rb;
    private Animator animator;

    [Header("Health")]
    [SerializeField] private int maxHealth;
    public int currentHealth;
    private bool IsDead;


    [Header("Movement")]
    [SerializeField] private float maxSpeed;
    [SerializeField] private float maxAcceleration;
    [SerializeField] private int jumpSpeed;
    [SerializeField] private Transform feet;
    [SerializeField] private LayerMask groundLayer;
    private int groundFrames;
    private int jumpkeyFrames;
    private bool IsJumping;
    private bool Jumped;

    [Header("Interaction")]
    [SerializeField] private LayerMask interactableLayer;
        
    [Header("Combat")]
    [SerializeField] private int attackDamage;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private LayerMask damageableLayer;
    #endregion

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
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

        if (Input.GetKeyDown(KeyCode.X))
        {
            ONInteract();
        }  
    }

    void FixedUpdate()
    {
        Move();
    }


    #region Metodos del jugador

     private void Move()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Speed", Mathf.Abs(inputX));
        
        var MovementCommand = new MovementCommand(inputX, inputY, rb, maxSpeed, maxAcceleration, transform);
        EventQueue.Instance.QueueCommand(MovementCommand);
    }

    private void Jump()
    {
        Jumped = true;
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");

        var AttackCommand = new AttackCommand(attackDamage, attackPoint, enemyLayer, damageableLayer);
        EventQueue.Instance.QueueCommand(AttackCommand);
    }

    private void ONInteract()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(attackPoint.position,new Vector2(1f, 1f), 0f, interactableLayer); // lo mismo que con el metodo attack pero esta vez para interactuar

        foreach (Collider2D items in colliders)
        {
            if (items.TryGetComponent(out IInteractable interactable))
            {
                interactable.Interact();
                Debug.Log(interactable);
            }
        }      
    }

    public void Death()
    {
        Debug.Log("died");
    }

#endregion   
}

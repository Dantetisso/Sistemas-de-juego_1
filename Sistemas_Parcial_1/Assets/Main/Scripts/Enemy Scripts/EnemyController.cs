using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamagable
{
    [SerializeField] private EnemyData data;
    [SerializeField] private Transform attackPoint;
    private HealthController health;
    private Animator animator;
    private CapsuleCollider2D coll;
    private float destroyTime;
    private float detectionDistance;
    private LayerMask playerLayer;
    private int damage;
    public bool IsDead;


    private void Start()
    {
        health = GetComponent<HealthController>();
        animator = GetComponent<Animator>();
        coll = GetComponent<CapsuleCollider2D>();

        health.maxHealth = data.maxHealth;
        health.currentHealth = health.maxHealth;
        damage = data.damage;
        playerLayer = data.playerMask;
        detectionDistance = data.distanceDetection;
        destroyTime = data.maxDestroyTime;
    }


    void Update()
    {
        if (IsDead)
        {
            destroyTime -= Time.deltaTime;
        }
        
        if (health.currentHealth <= 0)
        {
            Death();
        }

        // Vector2 Direction = (Playerprefab.transform.position - EnemyShootPoint.position).normalized;

        RaycastHit2D hitLeft = Physics2D.Raycast(attackPoint.position, Vector2.left, detectionDistance, playerLayer);
        RaycastHit2D hitRight = Physics2D.Raycast(attackPoint.position, Vector2.right, detectionDistance, playerLayer);

        if (hitRight)
        {
            Debug.Log("derecha");
        } 
        if (hitLeft)
        {
            Debug.Log("izquierda");
        }
        Debug.DrawLine(attackPoint.position, Vector3.left * detectionDistance + attackPoint.position, Color.red);
        Debug.DrawLine(attackPoint.position, Vector3.right * detectionDistance + attackPoint.position, Color.blue);

    }

    private void getdamage(int damage)
    {
        health.currentHealth -= damage;
    }
    
    public void GetDamage(int damage)
    {
        getdamage(damage);
    }

    private void Death()
    {    
        IsDead = true;
        coll.enabled = false;
        animator.SetTrigger("Death");
        Timer();
        transform.position = new Vector3(transform.position.x, -1, transform.position.z); // baja la posicion del enemy x culpa de la animacion de muerte
        
        if (destroyTime == 0)
        {
            Destroy(gameObject);
        }
    }

    private void Timer()
    {
        if (destroyTime > 0)
        {
            destroyTime -= Time.deltaTime;
        }
        else if (destroyTime < 0)
        {
            destroyTime = 0;
        }
    }

    private void Attack()
    {

    }

}

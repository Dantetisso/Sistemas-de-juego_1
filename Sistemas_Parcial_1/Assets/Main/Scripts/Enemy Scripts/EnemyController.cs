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
    private int damage;
    public bool IsDead;
    [SerializeField] private float maxTime;

  


    private void Start()
    {
        health = GetComponent<HealthController>();
        animator = GetComponent<Animator>();
        coll = GetComponent<CapsuleCollider2D>();

        health.maxHealth = data.maxHealth;
        health.currentHealth = health.maxHealth;
        damage = data.damage;
    }


    void Update()
    {
        if (IsDead)
        {
            maxTime -= Time.deltaTime;
        }
        
        if (health.currentHealth <= 0)
        {
            Death();
        }
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
       // transform.position = new Vector3(transform.position.x, -1, transform.position.z); // baja la posicion del enemy x culpa de la animacion de muerte
        
        if(maxTime == 0)
        {
            Destroy(gameObject);
        }
    }

    private void Timer()
    {
        if (maxTime > 0)
        {
            maxTime -= Time.deltaTime;
        }
        else if (maxTime < 0)
        {
            maxTime = 0;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamagable
{
    [SerializeField] private EnemyData data;
    private HealthController health;
    private Animator animator;
    private int damage;
    public bool IsDead;

    private void Start()
    {
        health = GetComponent<HealthController>();
        animator = GetComponent<Animator>();

        health.maxHealth = data.maxHealth;
        health.currentHealth = health.maxHealth;
        damage = data.damage;
    }


    void Update()
    {
        if (health.currentHealth < 0)
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
        animator.SetTrigger("Death");
        Destroy(gameObject);
    }

}

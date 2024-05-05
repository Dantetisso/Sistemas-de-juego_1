using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamagable
{
    [SerializeField] private EnemyData data;
    [SerializeField]private Transform attackPoint;
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
        animator.SetTrigger("Death");
       // transform.position = new Vector3(transform.position.x, -1, transform.position.z); // baja la posicion del enemy x culpa de la animacion de muerte
        Destroy(gameObject);
    }

}

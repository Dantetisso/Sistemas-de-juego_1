using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamagable
{
    [SerializeField] private EnemyData data;
    private HealthController health;
    private int damage;
    public bool IsDead;

    private void Start()
    {
        health = GetComponent<HealthController>();
        health.maxHealth = data.maxHealth;
        health.currentHealth = health.maxHealth;
        damage = data.damage;
    }

    private void getdamage(int damage)
    {
        health.currentHealth -= damage;
    }
    
    public void GetDamage(int damage)
    {
        getdamage(damage);
    }

    public void Death()
    {        
        Debug.Log("died");
    }

}

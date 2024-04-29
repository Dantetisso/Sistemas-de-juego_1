using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamagable
{
    [SerializeField] private EnemyData data;
    private int maxHealth;
    public int currentHealth;
    [SerializeField] private int maxDamage;
    public bool IsDead;


    private void Awake()
    {
        maxHealth = data.maxHealth;
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }

private void getdamage(int damage)
{
    currentHealth -= damage;
}
    public void GetDamage(int damage)
    {
        getdamage(damage);
    }


    public bool IsAlive()
    {
        return currentHealth > 0;
    }

    public void Death()
    {
        Debug.Log("died");
    }

}

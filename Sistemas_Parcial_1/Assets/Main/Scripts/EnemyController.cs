using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IHealth
{
    [SerializeField] private int maxHealth;
    public int currentHealth;
    [SerializeField] private int maxDamage;
    public bool IsDead;
 
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
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


}

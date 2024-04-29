using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    
    public void UpdateHealth() 
    {
        maxHealth = currentHealth;
    }
    private void getdamage(int damage)
    {
        currentHealth -= damage;
    }
    public void GetDamage(int damage) 
    {
        getdamage(damage);
    }
              
    public void Heal(int heal)
    {
        currentHealth += heal;

        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }
}

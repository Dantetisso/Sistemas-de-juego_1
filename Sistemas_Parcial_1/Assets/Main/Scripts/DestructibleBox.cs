using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleBox : MonoBehaviour, IDamagable
{  
    [SerializeField] private int maxHealth;
    private int health;

    void Start()
    {
        health = maxHealth;
    }
     private void getdamage(int damage)
    {
        health -= damage;
    }

     public void GetDamage(int damage)
    {
        getdamage(damage);
    }

   private void Update()
    {
        if (health < 0)
        {
            OnDestroy();
            Debug.Log("chau cajitaaa");
        }
    }

    private void OnDestroy()
    {
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleBox : MonoBehaviour//, IDamagable
{  
    private HealthController healthcontroller;

    void Start()
    {
        healthcontroller = GetComponent<HealthController>();
        healthcontroller.currentHealth = healthcontroller.maxHealth;
    }
/*     private void getdamage(int damage)
    {
        healthcontroller.currentHealth -= damage;
    }

     public void GetDamage(int damage)
    {
        getdamage(damage);
    }
*/
   private void Update()
    {
        if (healthcontroller.currentHealth < 0)
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

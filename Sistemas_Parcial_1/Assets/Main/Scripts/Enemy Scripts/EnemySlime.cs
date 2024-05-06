using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : EnemyController
{
    public int maxHealth;
    
    
    
    
    void Start()
    {
        maxHealth = EnemyController.FindObjectOfType<HealthController>().maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

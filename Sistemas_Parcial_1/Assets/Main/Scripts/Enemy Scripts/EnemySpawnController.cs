using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private EnemyController enemy;
    private int index;
   
    
    void Update()
    {      
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spawn();
        }
    }

    private void spawn()
    {
        while (index < spawnPoints.Length)
        {
            index++;
            Instantiate(enemy, spawnPoints[index]);
        }
    }
}

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
        spawn();
    }

    private void spawn()
    {
        for (int i = index; i < spawnPoints.Length; i++)
        {
            Instantiate(enemy, spawnPoints[i]);
        }
    }
}

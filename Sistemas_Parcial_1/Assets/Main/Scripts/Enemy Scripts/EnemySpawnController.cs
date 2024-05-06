using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private EnemyController enemy;
    private int index;
   
    void Start()
    {
        
    }
    
    void Update()
    {      
        for (int i = index; i < spawnPoints.Length; i++)
        {
            index++;
            Instantiate(enemy, spawnPoints[index]);
        }
    }
}

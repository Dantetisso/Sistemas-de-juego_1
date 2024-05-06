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

    [System.Obsolete]
    void Update()
    {//Random.RandomRange(0, spawnPoints.Length)
       // Transform position = spawnPoints[index];
       /* for (int i = 0; i < spawnPoints.Length; i++)
        {
            
        }*/

        while (index < spawnPoints.Length)
        {   
            index++;
            Instantiate(enemy, spawnPoints[index]);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new Enemy", menuName = ("Scriptable Objects/Enemy"))]
public class EnemyData : ScriptableObject
{
    [field: SerializeField] public int maxHealth {get; private set;}
    [field: SerializeField] public int speed {get; private set;}
    [field: SerializeField] public int damage {get; private set;}
    [field: SerializeField] public float distanceDetection {get; private set;}
    [field: SerializeField] public float maxDestroyTime {get; private set;}
    [field: SerializeField] public LayerMask playerMask {get; private set;}
    [field: SerializeField] public LayerMask groundMask {get; private set;}
}

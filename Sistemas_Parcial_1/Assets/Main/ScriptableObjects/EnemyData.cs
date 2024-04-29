using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new Enemy", menuName = ("Enemy"))]
public class EnemyData : ScriptableObject
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _speed;
    [SerializeField] private int _damage;
    [SerializeField] private LayerMask _playerMask;

    public int maxHealth => _maxHealth;
    public int speed => _speed;
    public int damage => _damage;
    public LayerMask playerMask => _playerMask;
    
}

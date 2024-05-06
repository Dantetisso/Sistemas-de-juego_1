using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : ICommand
{
    private readonly int attackDamage;
    private readonly Transform attackPoint;
    private readonly LayerMask enemyLayer;
    private readonly LayerMask damageableLayer;

    public AttackCommand(int _attackDamage, Transform _attackPoint, LayerMask _enemyLayer, LayerMask _damageableLayer)
    {
        attackDamage = _attackDamage;
        attackPoint = _attackPoint;
        enemyLayer = _enemyLayer;
        damageableLayer = _damageableLayer;
    } 

    public void Execute()
    {
        Collider2D[] hit = Physics2D.OverlapBoxAll(attackPoint.position, new Vector2(1f, 1f), 0f, damageableLayer);
        
        foreach (Collider2D objects in hit) // recorre array de collideres dentro de la mascara damageable y busca si tienen la interfaz damageable para hacerles daño
        {
            if (objects.TryGetComponent(out IDamagable damageable))
            {
                damageable.GetDamage(attackDamage);
                Debug.Log("<color=red>" + damageable + "</color>");
            }
        }  
    }
}

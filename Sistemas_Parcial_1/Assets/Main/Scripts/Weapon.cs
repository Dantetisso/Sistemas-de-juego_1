using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private readonly int damage;
    private readonly float range;


    public Weapon(int _damage, float _range)
    {
        damage = _damage;
        range = _range;
    }
}

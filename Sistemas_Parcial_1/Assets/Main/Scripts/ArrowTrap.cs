using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : Cloner, ICloneable
{
    // private int damage {get; set;}
    // private float speed {get; set;}

    // public ArrowTrap(int _damage, float _speed)
    // {
    //     damage = _damage;
    //     speed = _speed;
    // }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("funcoo");
        }
    }

    public ICloneable clon()
    {
        // var newArrowTrap = new ArrowTrap(damage, speed);
        return Instantiate(this);
    }
}

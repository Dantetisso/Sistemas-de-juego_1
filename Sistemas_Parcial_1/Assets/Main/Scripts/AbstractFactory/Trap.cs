using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Trap : IFactory
{
   public void spawn()
    {
        var enemy = new Factory();
        Trap created = (Trap)enemy.createItem();

        if (created != null){Debug.Log($"{created}");}
    }
}

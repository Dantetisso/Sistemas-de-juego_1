using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrapInfo : ICloneable
{
    public float speed {get; }
    public int damage {get; }
    public float lifeSpan {get; }

    public ArrowTrapInfo(float Speed, int Damage, float LifeSpan)
    {
        speed = Speed;
        damage = Damage;
        lifeSpan = LifeSpan;
    }
   
    public ICloneable Clone()
    {
        var newArrowTrapInfo = new ArrowTrapInfo(speed, damage, lifeSpan);
        return newArrowTrapInfo;
    }

    
}

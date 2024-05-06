using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrapInfo: ICloneable
{
    public float speed { get; }
    public int damage { get; }
    public float lifeSpan { get; }
    public Vector2 position { get; }

    public ArrowTrapInfo(Vector2 Position, float Speed, int Damage, float LifeSpan)
    {
        position = Position;
        speed = Speed;
        damage = Damage;
        lifeSpan = LifeSpan;
    }
   
    public ICloneable Clone()
    {
        var newArrowTrapInfo = new ArrowTrapInfo(position, speed, damage, lifeSpan);
        return newArrowTrapInfo;
    }

    
}

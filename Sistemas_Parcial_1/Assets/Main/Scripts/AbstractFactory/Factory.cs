using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : AbstractFactory
{
    public override IFactory createItem()
    {
        var newTrap = new Trap();
        return newTrap;
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Sword : Weapon
{
    public Sword(int _damage, float _range) : base(_damage, _range)
    {
        var sword = new Sword(10, 2);

    }
}

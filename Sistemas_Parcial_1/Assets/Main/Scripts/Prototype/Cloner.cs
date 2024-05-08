using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cloner 
{
    public static ICloneable CloneObject(ICloneable cloneable)
    {
        var newClone = cloneable.clon();
        return newClone;
    }
}

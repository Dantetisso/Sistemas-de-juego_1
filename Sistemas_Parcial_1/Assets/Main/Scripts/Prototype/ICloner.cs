using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICloner 
{
  ICloneable cloneObject(ICloneable cloneable);
}

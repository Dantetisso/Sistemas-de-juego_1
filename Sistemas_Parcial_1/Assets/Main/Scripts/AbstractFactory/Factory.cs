using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Factory : MonoBehaviour, IFactory
{
    public abstract IFactory createItem();
}

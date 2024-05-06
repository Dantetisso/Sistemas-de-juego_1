using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private Transform position;

   void OnTriggerEnter2D(Collider2D other)
   {
     var info = new ArrowTrapInfo(position.position, 10, 5, 10f);
     info.Clone();
   }
}

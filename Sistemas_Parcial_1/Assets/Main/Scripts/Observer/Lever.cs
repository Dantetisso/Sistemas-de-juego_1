using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    private Animator animator;
    [SerializeField] private GameObject door;
    private bool IsActivated;
 
   private void Start() 
   {
    animator = GetComponent<Animator>();
   }
   
    private void interact()
    {
        if (!IsActivated)
        {
            animator.SetTrigger("IsActioned");
            door.transform.Translate(0,2,0);
            IsActivated = true;
            UnSuscribe();
        }
    }
 
    public void Interact()
    {
        interact();
        Suscribe();
    }
      private void Suscribe()
    {
        PlayerController.OnInteract += interact;
    }

    private void UnSuscribe()
    {
        PlayerController.OnInteract -= interact;
    }
}

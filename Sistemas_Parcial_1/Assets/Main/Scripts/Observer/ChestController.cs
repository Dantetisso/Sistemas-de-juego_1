using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour, IInteractable
{   
    [SerializeField] private Animator animator;

    private void interact()
    {
        animator.SetBool("IsOpen", true);
        UnSuscribe();  
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

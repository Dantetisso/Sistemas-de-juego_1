using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour, IInteractable
{   
    private void interact()
    {
        transform.position = new Vector3(transform.position.x, 1, 0);
        Debug.Log("cofre abierto");
        UnSuscribe();  
    }
   
    public void Interact()
    {
        interact();
        Suscribe();
    }

     private void Suscribe()
    {
        PlayerController.OnInteract += Interact;
        Debug.Log("ARRIBAAA");
    }

    private void UnSuscribe()
    {
        PlayerController.OnInteract -= Interact;
        Debug.Log("<color=black>"+"AAAABAJOO"+"</color>");
    }
}

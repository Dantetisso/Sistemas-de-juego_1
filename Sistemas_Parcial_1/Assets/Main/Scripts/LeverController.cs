using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour, IInteractable
{
     private Animator animator;
     [SerializeField] private GameObject door;
 
   private void Start() 
   {
    animator = GetComponent<Animator>();
   }
   
    private void interact()
    {
        animator.SetTrigger("IsActioned");
        door.transform.Translate(0,2,0);
    }
 
    public void Interact()
    {
        interact();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

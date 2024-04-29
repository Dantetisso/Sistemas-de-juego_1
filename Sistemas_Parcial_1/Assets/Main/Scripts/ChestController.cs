using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour, IInteractable
{
    private void interact()
    {
        transform.position = new Vector3(transform.position.x,1,0);
        Debug.Log("holaaa");
    }

    public void Interact()
    {
        interact();
    }
}

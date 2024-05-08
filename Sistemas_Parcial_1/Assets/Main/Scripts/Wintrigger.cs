using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wintrigger : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.WinLevel();
        }
    }
}

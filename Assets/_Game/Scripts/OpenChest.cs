using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    [SerializeField] private GameObject openChest;
    [SerializeField] private GameObject closeChest;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            closeChest.SetActive(false);
            openChest.SetActive(true);
            
        }
    }
}

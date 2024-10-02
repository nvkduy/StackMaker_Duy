using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBrick2 : MonoBehaviour
{
    [SerializeField] private GameObject activeBrick;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           activeBrick.SetActive(true);
      
        }

        gameObject.tag = ("Untagged");
    }  
}

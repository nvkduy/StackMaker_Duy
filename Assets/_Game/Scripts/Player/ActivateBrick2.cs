using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBrick2 : MonoBehaviour
{
    public GameObject[] brickArray;
    private int curentIndex = 0;

    private void Start()
    {
        //GameObject[] brickArray = Resources.LoadAll<GameObject>("Bricks");
        //brickArray = GameObject.FindGameObjectsWithTag("brickDeActive");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("removeBrick"))
        {
           if (curentIndex < brickArray.Length)
            {
                brickArray[curentIndex].SetActive(true);
                curentIndex++;
            }

            other.gameObject.tag = "Untagged";
        }
    }  
}

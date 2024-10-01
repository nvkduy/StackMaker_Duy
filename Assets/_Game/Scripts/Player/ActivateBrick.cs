using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBrick : MonoBehaviour
{
    [SerializeField] private GameObject brickLine;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            Debug.Log("Brick Line: " + brickLine); // Xem giá trị của brickLine
            if (brickLine != null)
            {
                brickLine.SetActive(true);
                Debug.Log("Brick line activated.");
            }
            else
            {
                Debug.LogWarning("brickLine is not assigned in the Inspector.");
            }
        }
    }

}

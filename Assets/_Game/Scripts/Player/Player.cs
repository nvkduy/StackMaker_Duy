using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static MiniGestureRecognizer;

public class Player : MonoBehaviour
{
    private void OnEnable()
    {
        MiniGestureRecognizer.Swipe += OnSwipe;
    }

    private void OnSwipe(SwipeDirection swipeDirection)
    {
        Debug.Log("huong vuot: " + swipeDirection);

        

    }
}

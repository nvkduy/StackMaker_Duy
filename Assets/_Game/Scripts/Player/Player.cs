using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static MiniGestureRecognizer;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] private LayerMask brickLayer;

    private bool isMove;
    private Vector3 moveDir = Vector3.forward;

    private void Update()
    {
        Vector3 targetPos = GetTargetPos();

        
            
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed );
            Debug.Log("Moving to: " + targetPos);
            Debug.Log($"Current position: {transform.position}");
            
            if (Vector3.Distance(transform.position, targetPos) < 0.01f)
            {
                isMove = false; 
                Debug.Log("Reached target position");
            }
        
    }

    private void OnEnable()
    {
        MiniGestureRecognizer.Swipe += Move;
    }

    private void OnDisable()
    {
        MiniGestureRecognizer.Swipe -= Move; 
    }

    private Vector3 GetTargetPos()
    {
        Vector3 lastPos = transform.position;
        RaycastHit hit;
        Vector3 rayStart;
        Vector3 rayDir;
      
        for (int i = 0; i < 10; i++)
        {
            rayStart = transform.position + (moveDir*i)*1f + transform.up * 2f;
            rayDir = transform.position + (moveDir*i)*1f + Vector3.down * 2f;
            
            if (Physics.Raycast(rayStart, rayDir, out hit,brickLayer))
            {
                Debug.DrawLine(rayStart, rayDir, Color.red, 1f);
                lastPos = hit.point;
                Debug.Log("a" + lastPos);
                break;
                
            }
        }
        
       
        return lastPos;
           
    }

    private void Move(SwipeDirection dir)
    {
        Debug.Log("direciton " + dir);
       
            switch (dir)
            {
                case SwipeDirection.Up:
                    moveDir = Vector3.forward;
                    transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                    break;
                case SwipeDirection.Down:
                    moveDir = Vector3.back;
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    break;
                case SwipeDirection.Left:
                    moveDir = Vector3.left;
                    transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                    break;
                case SwipeDirection.Right:
                    moveDir = Vector3.right;
                    transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
                    break;
           
        }
    }
}

//using TMPro;
//using UnityEditor.Experimental.GraphView;
//using UnityEngine;
//using UnityEngine.Windows;
//using static MiniGestureRecognizer;
//using static UnityEngine.GraphicsBuffer;
//public class PlayerController : MonoBehaviour
//{

    

   

//    private void Update()
//    {
//        Vector3 enPos = GetTargetPos();
        
//    }

//    private Vector3 GetTargetPos()
//    {
//        Vector3 target = transform.position;
//        RaycastHit hit;
//        //for (int i = 0; i < 20; i++)
//        //{ 
//            Debug.DrawLine(transform.position + transform.forward * 2f + transform.up * 2f, transform.position + transform.forward * 2f + Vector3.down * 3f, Color.red, 1f);
//            if (Physics.Raycast(transform.position + transform.forward * 2f + transform.up * 2f, transform.position + transform.forward * 2f + Vector3.down * 3f, out hit, brickLayer))
//            {
//                target = hit.point;
//            }
            
//        //}
//        return target;
//    }

//    void Move(SwipeDirection dir, Vector3 endPos)
//    {
//        Vector3 movementDirection = Vector3.zero;

//        switch (dir)
//        {
//            case SwipeDirection.Up:
//                movementDirection = transform.position + Vector3.forward; 
//                break;
//            case SwipeDirection.Down:
//                movementDirection = transform.position + Vector3.back; 
//                break;
//            case SwipeDirection.Left:
//                movementDirection = transform.position + Vector3.left; 
//                break;
//            case SwipeDirection.Right:
//                movementDirection = transform.position + Vector3.right;
//                break;
//        }
//        transform.position = Vector3.MoveTowards(transform.position, movementDirection, moveSpeed);

       
//}
//}

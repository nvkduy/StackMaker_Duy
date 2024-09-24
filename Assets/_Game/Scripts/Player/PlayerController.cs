using TMPro;
using UnityEngine;
public class PlayerController : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] private LayerMask BrickLayer;
    private Vector3 target;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        GetTargetPos();
    }
    private void OnEnable()
    {
        MiniGestureRecognizer.Swipe += HandleSwipe;
    }

    private void OnDisable()
    {
        MiniGestureRecognizer.Swipe -= HandleSwipe;
    }

    private void GetTargetPos()
    {
       
        RaycastHit hit;
        Debug.DrawLine(transform.position + Vector3.up * 2f,Vector3.down * 2f, Color.red);
        if (Physics.Raycast(transform.position + Vector3.up * 2f, Vector3.down, out hit, 2f, BrickLayer))
        {
            target = hit.point;
        }
    }
    private void HandleSwipe(MiniGestureRecognizer.SwipeDirection direction)
    {

        switch (direction)
        {
            case MiniGestureRecognizer.SwipeDirection.Up:
                target = transform.position + Vector3.forward;
                break;
            case MiniGestureRecognizer.SwipeDirection.Down:
                target = transform.position + Vector3.back;
                break;
            case MiniGestureRecognizer.SwipeDirection.Right:
                target = transform.position + Vector3.right;
                break;
            case MiniGestureRecognizer.SwipeDirection.Left:
                target = transform.position + Vector3.left;
                break;
        }



    }
}

using UnityEngine;
using System;


public class MiniGestureRecognizer : MonoBehaviour
{
    public enum SwipeDirection
    {
        Up,
        Down,
        Right,
        Left
    }

    public static event Action<SwipeDirection> Swipe; // Sự kiện để thông báo về các thao tác vuốt

    private bool swiping = false; // Biến kiểm tra trạng thái vuốt
    private bool eventSent = false; // Biến kiểm tra xem sự kiện đã được gửi hay chưa
    private Vector2 lastPosition; // Biến lưu vị trí trước đó của ngón tay

    void Update()
    {
        // Kiểm tra xem có chạm nào không
        if (Input.touchCount == 0)
            return;

        // Kiểm tra sự thay đổi vị trí của chạm đầu tiên
        if (Input.GetTouch(0).deltaPosition.sqrMagnitude != 0)
        {
            if (!swiping)
            {
                // Bắt đầu vuốt
                swiping = true;
                lastPosition = Input.GetTouch(0).position; // Lưu vị trí hiện tại
                return;
            }
            else
            {
                if (!eventSent) // Kiểm tra xem sự kiện đã được gửi chưa
                {
                    // Gửi sự kiện vuốt
                    Vector2 direction = Input.GetTouch(0).position - lastPosition;

                    // Xác định hướng vuốt
                    if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                    {
                        Swipe?.Invoke(direction.x > 0 ? SwipeDirection.Right : SwipeDirection.Left);
                    }
                    else
                    {
                        Swipe?.Invoke(direction.y > 0 ? SwipeDirection.Up : SwipeDirection.Down);
                    }

                    eventSent = true; // Đánh dấu sự kiện đã được gửi
                }
            }
        }
        else
        {
            // Kết thúc vuốt
            swiping = false;
            eventSent = false; // Đặt lại trạng thái gửi sự kiện
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Biến khai báo tốc độ di chuyển của nhân vật (giá trị mặc định = 5)
    public float speed = 5;

    // Biến tham chiếu đến component Rigidbody2D của Player để xử lý vận tốc vật lý
    public Rigidbody2D RB;

    // Chức năng của hàm: FixedUpdate chạy cố định 50 lần/giây, giúp tính toán vật lý (Rigidbody) chính xác và mượt mà, không phụ thuộc vào biến động tốc độ khung hình (FPS)
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        RB.velocity = new Vector2(horizontal, vertical) * speed;
    }
}
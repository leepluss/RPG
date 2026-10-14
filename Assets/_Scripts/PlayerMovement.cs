using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Tốc độ di chuyển của nhân vật (mặc định = 5)
    public float speed = 5f;

    // Biến tham chiếu đến Rigidbody2D để xử lý vận tốc vật lý
    public Rigidbody2D RB;

    // Biến tham chiếu đến Animator để điều khiển các trạng thái animation (Idle, Walking)
    public Animator anim;

    // Biến lưu trữ giá trị đầu vào trục ngang (A/D hoặc phím Trái/Phải)
    private float horizontal;

    // Biến lưu trữ giá trị đầu vào trục dọc (W/S hoặc phím Lên/Xuống)
    private float vertical;

    // Biến theo dõi hướng mặt nhân vật: 1 nghĩa là quay sang Phải, -1 nghĩa là quay sang Trái
    private int facingDirection = 1;

    // Chức năng của hàm: FixedUpdate chạy cố định 50 lần/giây, chuyên xử lý vật lý và di chuyển nhân vật mượt mà
    private void FixedUpdate()
    {
        // Đọc giá trị phím bấm từ trục ngang (trả về từ -1.0 đến 1.0)
        horizontal = Input.GetAxis("Horizontal");

        // Đọc giá trị phím bấm từ trục dọc (trả về từ -1.0 đến 1.0)
        vertical = Input.GetAxis("Vertical");

        // Gán vận tốc di chuyển cho Rigidbody2D bằng Vector2 nhân với tốc độ
        RB.velocity = new Vector2(horizontal, vertical) * speed;

        // Truyền giá trị tuyệt đối (Mathf.Abs) của horizontal vào tham số "horizontal" trong Animator để chuyển sang animation Walk khi bấm Trái/Phải
        anim.SetFloat("horizontal", Mathf.Abs(horizontal));

        // Truyền giá trị tuyệt đối (Mathf.Abs) của vertical vào tham số "vertical" trong Animator để chuyển sang animation Walk khi bấm Lên/Xuống
        anim.SetFloat("vertical", Mathf.Abs(vertical));

        // Kiểm tra điều kiện cần lật mặt: Bấm Phải khi mặt đang quay Trái HOẶC bấm Trái khi mặt đang quay Phải
        if ((horizontal > 0 && transform.localScale.x < 0) || (horizontal < 0 && transform.localScale.x > 0))
        {
            // Gọi hàm Flip để thực hiện lật mặt nhân vật
            Flip();
        }
    }

    // Chức năng của hàm: Thực hiện lật scale trục X của nhân vật để xoay mặt hướng Trái / Phải
    private void Flip()
    {
        // Đảo ngược giá trị hướng mặt hiện tại (1 thành -1 hoặc -1 thành 1)
        facingDirection *= -1;

        // Tạo Vector3 mới đảo dấu trục X (nhân với -1) và giữ nguyên vị trí trục Y, Z của localScale
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevation_exit : MonoBehaviour
{
    // Mảng lưu trữ các tham chiếu Collider 2D của núi cần bật lại khi Player đã đi xuống dưới chân núi
    public Collider2D[] mountainColliders;

    // Mảng lưu trữ các tham chiếu Collider 2D ranh giới cần tắt đi khi Player trở về mặt đất
    public Collider2D[] boundaryColliders;

    // Chức năng của hàm: Sự kiện tự động kích hoạt khi Player bước vào vùng Trigger lối ra tại chân núi
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Điều kiện kiểm tra: Đảm bảo chỉ đối tượng có Tag "Player" mới kích hoạt quá trình xuống núi
        if (collision.gameObject.tag == "Player")
        {
            // Chức năng của vòng lặp: Duyệt qua từng Collider núi trong mảng mountainColliders và khôi phục va chạm
            foreach (Collider2D mountain in mountainColliders)
            {
                // Bật lại va chạm của vách núi để núi trở thành chướng ngại vật cản Player khi đứng ở bên dưới
                mountain.enabled = true;
            }

            // Chức năng của vòng lặp: Duyệt qua từng Collider ranh giới trong mảng boundaryColliders và vô hiệu hóa va chạm
            foreach (Collider2D boundary in boundaryColliders)
            {
                // Tắt va chạm ranh giới ẩn để Player có thể tự do di chuyển dưới mặt đất mà không bị vướng tường vô hình
                boundary.enabled = false;
            }

            // Chức năng của dòng lệnh: Khôi phục Sorting Order của Player về lại giá trị ban đầu (10)
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 10;
        }
    }
}
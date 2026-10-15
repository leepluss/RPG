using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevation_entry : MonoBehaviour
{
    // Mảng lưu trữ các tham chiếu Collider 2D của núi (Collision High và Collision Low) cần tắt khi Player đi lên núi
    public Collider2D[] mountainColliders;

    // Mảng lưu trữ các tham chiếu Collider 2D ranh giới (Mountain Boundary) cần bật để giữ Player không bị rơi khỏi đỉnh núi
    public Collider2D[] boundaryColliders;

    // Chức năng của hàm: Sự kiện tự động kích hoạt khi một Collider khác bước vào vùng Trigger của lối vào núi
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Điều kiện kiểm tra: Chỉ thực hiện logic nếu đối tượng va chạm mang Tag là "Player"
        if (collision.gameObject.tag == "Player")
        {
            foreach (Collider2D mountain in mountainColliders)
            {
                mountain.enabled = false;
            }
            foreach (Collider2D boundary in boundaryColliders)
            {
                boundary.enabled = true;
            }
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 15;
        }
    }
}
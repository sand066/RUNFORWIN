using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    public Transform startPoint; // ตำแหน่งเริ่มต้นที่กำหนดไว้

    void OnTriggerEnter2D(Collider2D other)
    {
        // ตรวจสอบว่าตัวละคร (หรือ Player) ชนเข้ากับ Collider นี้
        if (other.CompareTag("Player"))
        {
            // ย้ายตัวละครกลับไปที่ตำแหน่งเริ่มต้น
            other.transform.position = startPoint.position;
            // รีเซ็ตความเร็วหรือสถานะอื่น ๆ ของตัวละครถ้ามี
            // เช่น ถ้าใช้ Rigidbody ให้รีเซ็ตความเร็ว
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
                rb.angularVelocity = 0f;
            }
        }
    }
}

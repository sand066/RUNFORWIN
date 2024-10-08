using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    // กำหนดความสูงที่ผู้เล่นจะเด่นขึ้นไป
    public float bounceForce = 0;

    // เมื่อมีการชนเกิดขึ้น
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ตรวจสอบว่าวัตถุที่ชนเป็นผู้เล่นหรือไม่
        if (collision.gameObject.CompareTag("Player"))
        {
            // สร้างเวกเตอร์ที่ชี้ขึ้น
            Vector2 bounceDirection = Vector2.up;

            // ปรับปรุงความเร็วของผู้เล่นโดยใช้แรงเด่น
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = bounceDirection * bounceForce;
        }
    }
}

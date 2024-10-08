using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carmove : MonoBehaviour
{
    public float detectionRange = 30f; // ระยะทางที่จะใช้ในการตรวจจับผู้เล่น
    public float moveSpeed = 0.01f; // ความเร็วในการเคลื่อนที่
    public Vector3 initialPosition; // ตำแหน่งเริ่มต้นของรถ

    private Transform player; // ตำแหน่งของผู้เล่น

    void Start()
    {
        // หาตำแหน่งของผู้เล่น
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // เก็บตำแหน่งเริ่มต้นของรถ
        initialPosition = transform.position;
    }

    void Update()
    {
        // ตรวจสอบว่าผู้เล่นอยู่ในระยะหรือไม่
        if (Vector3.Distance(transform.position, player.position) <= detectionRange)
        {
            // เคลื่อนที่ไปทางซ้าย
            transform.position += Vector3.left * moveSpeed;
        }
        else
        {
            // ถ้าไม่พบผู้เล่น ให้รีเซ็ตตำแหน่งของรถเป็นตำแหน่งเริ่มต้น
            transform.position = initialPosition;
        }
    }
}
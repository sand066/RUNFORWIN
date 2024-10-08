using UnityEngine;
using UnityEngine.SceneManagement;

public class diecheck : MonoBehaviour
{
    // เมื่อมีการชนกับเอนทิตี้
    private void OnTriggerEnter(Collider2D other)
    {
        // ตรวจสอบว่าชนกับเอนทิตี้ของผู้เล่นหรือไม่
        if (other.CompareTag("Player"))
        {
            // เรียกใช้งานฟังก์ชัน RestartGame เพื่อเริ่มเกมใหม่
            RestartGame();
        }
    }

    // ฟังก์ชันสำหรับเริ่มเกมใหม่
    private void RestartGame()
    {
        // เรียกใช้งาน SceneManager.LoadScene() เพื่อโหลดซีนปัจจุบันใหม่
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

using UnityEngine;

public class SlowDownOnStep : MonoBehaviour
{
    // ความเร็วที่ต้องการให้ลดลงเมื่อผู้เล่นเหยียบ
    public float slowSpeedMultiplier = 0.5f;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                player.ApplySlowEffect(slowSpeedMultiplier);
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                player.RemoveSlowEffect();
            }
        }
    }
}
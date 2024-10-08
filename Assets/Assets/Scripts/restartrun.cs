using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    public Transform startPoint; // ���˹�������鹷���˹����

    void OnTriggerEnter2D(Collider2D other)
    {
        // ��Ǩ�ͺ��ҵ���Ф� (���� Player) ����ҡѺ Collider ���
        if (other.CompareTag("Player"))
        {
            // ���µ���Фá�Ѻ价����˹��������
            other.transform.position = startPoint.position;
            // ���絤�����������ʶҹ���� � �ͧ����Фö����
            // �� ����� Rigidbody ������絤�������
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
                rb.angularVelocity = 0f;
            }
        }
    }
}

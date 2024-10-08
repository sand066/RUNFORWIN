using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    // ��˹������٧�������蹨��蹢���
    public float bounceForce = 0;

    // ������ա�ê��Դ���
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ��Ǩ�ͺ����ѵ�ط�誹�繼������������
        if (collision.gameObject.CompareTag("Player"))
        {
            // ���ҧ�ǡ����������
            Vector2 bounceDirection = Vector2.up;

            // ��Ѻ��ا�������Ǣͧ�����������ç��
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = bounceDirection * bounceForce;
        }
    }
}

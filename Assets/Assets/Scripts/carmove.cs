using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carmove : MonoBehaviour
{
    public float detectionRange = 30f; // ���зҧ������㹡�õ�Ǩ�Ѻ������
    public float moveSpeed = 0.01f; // ��������㹡������͹���
    public Vector3 initialPosition; // ���˹�������鹢ͧö

    private Transform player; // ���˹觢ͧ������

    void Start()
    {
        // �ҵ��˹觢ͧ������
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // �纵��˹�������鹢ͧö
        initialPosition = transform.position;
    }

    void Update()
    {
        // ��Ǩ�ͺ��Ҽ���������������������
        if (Vector3.Distance(transform.position, player.position) <= detectionRange)
        {
            // ����͹���价ҧ����
            transform.position += Vector3.left * moveSpeed;
        }
        else
        {
            // �����辺������ ������絵��˹觢ͧö�繵��˹��������
            transform.position = initialPosition;
        }
    }
}
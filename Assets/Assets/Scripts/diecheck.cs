using UnityEngine;
using UnityEngine.SceneManagement;

public class diecheck : MonoBehaviour
{
    // ������ա�ê��Ѻ�͹�Ե��
    private void OnTriggerEnter(Collider2D other)
    {
        // ��Ǩ�ͺ��Ҫ��Ѻ�͹�Ե��ͧ�������������
        if (other.CompareTag("Player"))
        {
            // ���¡��ҹ�ѧ��ѹ RestartGame ���������������
            RestartGame();
        }
    }

    // �ѧ��ѹ����Ѻ�����������
    private void RestartGame()
    {
        // ���¡��ҹ SceneManager.LoadScene() ������Ŵ�չ�Ѩ�غѹ����
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

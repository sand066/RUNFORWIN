using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{
    public GameObject winUI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShowWinUI();
            Time.timeScale = 0f; // ËÂØ´à¡Á
            Interstitial.Instance.ShowAd();
        }
    }

    void ShowWinUI()
    {
        if (winUI != null)
        {
            winUI.SetActive(true);
        }
    }
}
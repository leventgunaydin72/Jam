using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kazan1 : MonoBehaviour
{
    public TMP_Text winText; // D��ar�dan eklenen TMP_Text referans�
    public string nextSceneName = "NextLevel"; // Sonraki seviyenin ad�

    void OnCollisionEnter2D(Collision2D collision)
    {
        // E�er top arkadaki ��eye �arparsa
        if (collision.gameObject.CompareTag("Player"))
        {
            // Kazanma yaz�s�n� g�ster
            if (winText != null)
            {
                // Yaz�y� aktif hale getir
                winText.gameObject.SetActive(true);
                winText.text = "Bitti!";
            }

            // Sonraki sahneye ge�i� i�lemi ba�lat
            Invoke("LoadNextScene", 0.2f);
        }
    }

    void LoadNextScene()
    {
        // Sonraki sahneye ge�
        SceneManager.LoadScene(nextSceneName);
    }
}

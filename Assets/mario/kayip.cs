using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kayip : MonoBehaviour
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
                winText.text = "Kaybettin!";
            }

            // Sonraki sahneye ge�i� i�lemi ba�lat
            Invoke("LoadNextScene", 0.3f);
        }
    }

    void LoadNextScene()
    {
        // Sonraki sahneye ge�
        SceneManager.LoadScene(nextSceneName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class kazan : MonoBehaviour
{
    public TMP_Text winText; // Dýþarýdan eklenen TMP_Text referansý
    public string nextSceneName = "NextLevel"; // Sonraki seviyenin adý

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Eðer top arkadaki öðeye çarparsa
        if (collision.gameObject.CompareTag("top"))
        {
            // Kazanma yazýsýný göster
            if (winText != null)
            {
                // Yazýyý aktif hale getir
                winText.gameObject.SetActive(true);
                winText.text = "Kazandýn!";
            }

            // Sonraki sahneye geçiþ iþlemi baþlat
            Invoke("LoadNextScene", 1f);
        }
    }

    void LoadNextScene()
    {
        // Sonraki sahneye geç
        SceneManager.LoadScene(nextSceneName);
    }
}
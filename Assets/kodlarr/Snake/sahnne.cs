using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sahnne : MonoBehaviour
{
    public int targetFoodCount = 10; // Hedef Food say�s�
    public Text winText; // Kazand�n�z mesaj�n� g�sterecek Text UI

    private int destroyedFoodCount = 0; // Yokedilen Food say�s�

    // Food yok oldu�unda �a�r�l�r
    public void OnFoodDestroyed()
    {
        destroyedFoodCount++; // Yokedilen Food say�s�n� art�r
        // E�er hedefe ula��ld�ysa
        if (destroyedFoodCount >= targetFoodCount)
        {
            WinGame(); // Oyunu kazan
        }
    }

    // Oyunu kazand���nda �a�r�l�r
    private void WinGame()
    {
        // Kazand�n�z mesaj�n� g�ster
        if (winText != null)
        {
            winText.text = "Kazand�n�z!";
        }
        // �ste�e ba�l� olarak bir sonraki sahneye ge�ebilirsiniz
        // SceneManager.LoadScene("SonrakiSahne");
    }
}
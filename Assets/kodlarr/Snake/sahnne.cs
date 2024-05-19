using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sahnne : MonoBehaviour
{
    public int targetFoodCount = 10; // Hedef Food sayýsý
    public Text winText; // Kazandýnýz mesajýný gösterecek Text UI

    private int destroyedFoodCount = 0; // Yokedilen Food sayýsý

    // Food yok olduðunda çaðrýlýr
    public void OnFoodDestroyed()
    {
        destroyedFoodCount++; // Yokedilen Food sayýsýný artýr
        // Eðer hedefe ulaþýldýysa
        if (destroyedFoodCount >= targetFoodCount)
        {
            WinGame(); // Oyunu kazan
        }
    }

    // Oyunu kazandýðýnda çaðrýlýr
    private void WinGame()
    {
        // Kazandýnýz mesajýný göster
        if (winText != null)
        {
            winText.text = "Kazandýnýz!";
        }
        // Ýsteðe baðlý olarak bir sonraki sahneye geçebilirsiniz
        // SceneManager.LoadScene("SonrakiSahne");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public string pauseSceneName = "pause1"; // Pause sahnesinin adý
    public static pause instance;

    void Update()
    {
        // Eðer ESC tuþuna basýldýysa
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Eðer aktif sahne pause sahnesi deðilse
            if (SceneManager.GetActiveScene().name != pauseSceneName)
            {
                // Aktif sahnenin indeksini PlayerPrefs'ta sakla
                PlayerPrefs.SetInt("LastScene", SceneManager.GetActiveScene().buildIndex);
                // Pause sahnesini yükle
                SceneManager.LoadScene(pauseSceneName);
            }
        }
    }

    // Continue butonuna basýldýðýnda çaðýrýlacak
    public void ReturnToPreviousScene()
    {
        // "LastScene" adlý kayýttan son sahnenin numarasýný alýp bu sahneye dön
        int lastScene = PlayerPrefs.GetInt("LastScene");
        SceneManager.LoadScene(lastScene);
    }
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
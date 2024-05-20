using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public string pauseSceneName = "pause1"; // Pause sahnesinin ad�
    public static pause instance;

    void Update()
    {
        // E�er ESC tu�una bas�ld�ysa
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // E�er aktif sahne pause sahnesi de�ilse
            if (SceneManager.GetActiveScene().name != pauseSceneName)
            {
                // Aktif sahnenin indeksini PlayerPrefs'ta sakla
                PlayerPrefs.SetInt("LastScene", SceneManager.GetActiveScene().buildIndex);
                // Pause sahnesini y�kle
                SceneManager.LoadScene(pauseSceneName);
            }
        }
    }

    // Continue butonuna bas�ld���nda �a��r�lacak
    public void ReturnToPreviousScene()
    {
        // "LastScene" adl� kay�ttan son sahnenin numaras�n� al�p bu sahneye d�n
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
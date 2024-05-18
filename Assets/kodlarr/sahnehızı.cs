using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sahnehızı : MonoBehaviour
{
    public float timeScaleMultiplier = 2f; // Zaman ölçeği çarpanı
    public string activeSceneName = "pong"; // Hızın arttırılacağı sahnenin adı

    void Start()
    {
        // Belirli bir sahnede başlangıçta zaman ölçeğini artır
        if (SceneManager.GetActiveScene().name == activeSceneName)
        {
            Time.timeScale = timeScaleMultiplier;
        }
    }

    void Update()
    {
        // Sahne değişikliklerini kontrol et
        if (SceneManager.GetActiveScene().name != activeSceneName)
        {
            // Belirli sahne dışındaysak zaman ölçeğini sıfırla
            Time.timeScale = 1f;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class quit : MonoBehaviour
{
    void Start()
    {
        // TMP butonuna týklama olayýný ekle
        GetComponent<Button>().onClick.AddListener(() => QuitGame());
    }

    // Oyunu kapat
    void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
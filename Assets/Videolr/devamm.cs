using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class devamm : MonoBehaviour
{
    public void ReturnToPreviousScene()
    {
        // "LastScene" adl� kay�ttan  son sahnenin numaras�n� al�p bu sahneye d�n
        int lastScene = PlayerPrefs.GetInt("LastScene");
        SceneManager.LoadScene(lastScene);
    }
}
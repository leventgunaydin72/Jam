using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class devamm : MonoBehaviour
{
    public void ReturnToPreviousScene()
    {
        // "LastScene" adlý kayýttan  son sahnenin numarasýný alýp bu sahneye dön
        int lastScene = PlayerPrefs.GetInt("LastScene");
        SceneManager.LoadScene(lastScene);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class bastan : MonoBehaviour
{
    public void ChangeSceneOnClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
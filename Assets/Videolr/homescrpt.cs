using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homescrpt : MonoBehaviour
{
    public float delay = 8.7f;

    void Start()
    {
        Invoke("DeactivateGameObject", delay);
    }

    void DeactivateGameObject()
    {
        Debug.Log("GameObject kapanýyor: " + gameObject.name);
        gameObject.SetActive(false);
    }
}
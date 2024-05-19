using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasbkl : MonoBehaviour
{
    public float delay = 9f;
    public GameObject targetObject;

    void Start()
    {
        targetObject.SetActive(false); // ��e ba�lang��ta kapal� olarak ayarlan�r
        Invoke("ActivateObject", delay);
    }

    void ActivateObject()
    {
        targetObject.SetActive(true); // Belirtilen gecikme s�resinden sonra ��e etkinle�tirilir
    }
}
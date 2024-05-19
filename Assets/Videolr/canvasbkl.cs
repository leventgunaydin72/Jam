using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasbkl : MonoBehaviour
{
    public float delay = 9f;
    public GameObject targetObject;

    void Start()
    {
        targetObject.SetActive(false); // Öðe baþlangýçta kapalý olarak ayarlanýr
        Invoke("ActivateObject", delay);
    }

    void ActivateObject()
    {
        targetObject.SetActive(true); // Belirtilen gecikme süresinden sonra öðe etkinleþtirilir
    }
}
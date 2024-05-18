using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Hareket h�z�
    public float moveSpeed = 5f;

    // Yukar� ve a�a�� limitler
    public float upperLimit = 4f;
    public float lowerLimit = -4f;

    void Update()
    {
        // Kullan�c� giri�ini al
        float moveInput = Input.GetAxis("Vertical");

        // Yeni y pozisyonunu hesapla
        float newY = transform.position.y + moveInput * moveSpeed * Time.deltaTime;

        // Pozisyonu s�n�rlar i�inde tut
        newY = Mathf.Clamp(newY, lowerLimit, upperLimit);

        // Yeni pozisyonu ayarla
        transform.position = new Vector2(transform.position.x, newY);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Hareket hýzý
    public float moveSpeed = 5f;

    // Yukarý ve aþaðý limitler
    public float upperLimit = 4f;
    public float lowerLimit = -4f;

    void Update()
    {
        // Kullanýcý giriþini al
        float moveInput = Input.GetAxis("Vertical");

        // Yeni y pozisyonunu hesapla
        float newY = transform.position.y + moveInput * moveSpeed * Time.deltaTime;

        // Pozisyonu sýnýrlar içinde tut
        newY = Mathf.Clamp(newY, lowerLimit, upperLimit);

        // Yeni pozisyonu ayarla
        transform.position = new Vector2(transform.position.x, newY);
    }
}
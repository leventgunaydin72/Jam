using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public float moveSpeed = 5f; // Karakterin hareket h�z�n� kontrol eder
    private Rigidbody2D rb;

    void Start()
    {
        // Ba�lang��ta karakterin Rigidbody2D bile�enini al�r
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // GetAxis "Horizontal" ile y�n tu�lar�n� kontrol eder
        float moveX = Input.GetAxis("Horizontal");

        // Karakterin h�z�n� ayarlar
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public float moveSpeed = 5f; // Karakterin hareket hýzýný kontrol eder
    private Rigidbody2D rb;

    void Start()
    {
        // Baþlangýçta karakterin Rigidbody2D bileþenini alýr
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // GetAxis "Horizontal" ile yön tuþlarýný kontrol eder
        float moveX = Input.GetAxis("Horizontal");

        // Karakterin hýzýný ayarlar
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 10f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Yer�ekiminden etkilenmemesi i�in yer�ekimi �l�e�ini s�f�rla
    }

    void Update()
    {
        MoveLeft();
    }

    private void MoveLeft()
    {
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour
{
    // Hareket h�z�
    public float moveSpeed = 5f;

    // Topun ba�lang�� hareket y�n�
    private Vector2 direction;

    void Start()
    {
        // Ba�lang��ta topun rastgele bir y�ne hareket etmesini sa�la
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(-1f, 1f);
        direction = new Vector2(x, y).normalized;
    }

    void Update()
    {
        // Topu hareket ettir
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // E�er top player tag'ine sahip bir �ubu�a �arparsa
        if (collision.gameObject.CompareTag("Player"))
        {
            // �arpma noktas�n� al
            Vector2 normal = collision.contacts[0].normal;

            // �arpma y�n�n� hesapla ve topun y�n�n� de�i�tir
            direction = Vector2.Reflect(direction, normal);
        }
    }
}
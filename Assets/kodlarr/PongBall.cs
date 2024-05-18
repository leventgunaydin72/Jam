using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour
{
    // Hareket hýzý
    public float moveSpeed = 5f;

    // Topun baþlangýç hareket yönü
    private Vector2 direction;

    void Start()
    {
        // Baþlangýçta topun rastgele bir yöne hareket etmesini saðla
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
        // Eðer top player tag'ine sahip bir çubuða çarparsa
        if (collision.gameObject.CompareTag("Player"))
        {
            // Çarpma noktasýný al
            Vector2 normal = collision.contacts[0].normal;

            // Çarpma yönünü hesapla ve topun yönünü deðiþtir
            direction = Vector2.Reflect(direction, normal);
        }
    }
}
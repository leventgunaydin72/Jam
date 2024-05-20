using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dondurma : MonoBehaviour
{
    public float hareketHizi = 5f;  // karakterin hareket h�z�
    private float timer = 9f;  // hareketi ba�latmak i�in bekleyece�imiz s�re

    void Update()
    {
        timer -= Time.deltaTime;  // timer'� azalt

        // timer 0'dan k���kse, hareketi ba�lat
        if (timer <= 0)
        {
            float hareketX = Input.GetAxis("Horizontal");  // yatay hareket
            float hareketY = Input.GetAxis("Vertical");  // dikey hareket

            Vector2 hareket = new Vector2(hareketX, hareketY);  // hareket vekt�r�n� olu�tur

            // karakteri belirlenen h�zda hareket ettir
            GetComponent<Rigidbody2D>().velocity = hareket * hareketHizi;
        }
    }
}
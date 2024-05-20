using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dondurma : MonoBehaviour
{
    public float hareketHizi = 5f;  // karakterin hareket hýzý
    private float timer = 9f;  // hareketi baþlatmak için bekleyeceðimiz süre

    void Update()
    {
        timer -= Time.deltaTime;  // timer'ý azalt

        // timer 0'dan küçükse, hareketi baþlat
        if (timer <= 0)
        {
            float hareketX = Input.GetAxis("Horizontal");  // yatay hareket
            float hareketY = Input.GetAxis("Vertical");  // dikey hareket

            Vector2 hareket = new Vector2(hareketX, hareketY);  // hareket vektörünü oluþtur

            // karakteri belirlenen hýzda hareket ettir
            GetComponent<Rigidbody2D>().velocity = hareket * hareketHizi;
        }
    }
}
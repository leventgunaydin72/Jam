using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frezee : MonoBehaviour
{
    public float freezeDuration = 9f; // Hareketin dondurulaca�� s�re (saniye)
    private bool isFrozen = true; // Hareketin dondurulup dondurulmad���n� belirten bayrak

    void Start()
    {
        // Belirli bir s�re sonra hareketin serbest b�rak�lmas� i�in bir coroutine ba�lat�l�r
        StartCoroutine(UnfreezeAfterDuration());
    }

    void Update()
    {
        // E�er dondurulmam��sa, karakterin hareket kodu buraya gelebilir
        if (!isFrozen)
        {
            // Karakterin hareket kodu buraya gelir
            // �rnek: Karakteri sa�a do�ru hareket ettirme kodu
            // transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
    }

    IEnumerator UnfreezeAfterDuration()
    {
        // Belirli bir s�re bekler
        yield return new WaitForSeconds(freezeDuration);

        // Hareketi serbest b�rak�r
        isFrozen = false;
    }
}
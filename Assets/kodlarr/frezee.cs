using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frezee : MonoBehaviour
{
    public float freezeDuration = 9f; // Hareketin dondurulacaðý süre (saniye)
    private bool isFrozen = true; // Hareketin dondurulup dondurulmadýðýný belirten bayrak

    void Start()
    {
        // Belirli bir süre sonra hareketin serbest býrakýlmasý için bir coroutine baþlatýlýr
        StartCoroutine(UnfreezeAfterDuration());
    }

    void Update()
    {
        // Eðer dondurulmamýþsa, karakterin hareket kodu buraya gelebilir
        if (!isFrozen)
        {
            // Karakterin hareket kodu buraya gelir
            // Örnek: Karakteri saða doðru hareket ettirme kodu
            // transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
    }

    IEnumerator UnfreezeAfterDuration()
    {
        // Belirli bir süre bekler
        yield return new WaitForSeconds(freezeDuration);

        // Hareketi serbest býrakýr
        isFrozen = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class text : MonoBehaviour
{
    private TextMeshProUGUI tmpObject;

    private void Start()
    {
        // TMP nesnesini GameObject'in �ocuklar� aras�nda bul
        tmpObject = GetComponentInChildren<TextMeshProUGUI>();

        // TMP nesnesi bulunduysa aktif yap
        if (tmpObject != null)
        {
            tmpObject.gameObject.SetActive(true);

            // 2 saniye sonra TMP nesnesini inaktif yapacak Coroutine ba�lat
            StartCoroutine(DeactivateTMPAfterDelay(1.5f));
        }
        else
        {
            Debug.LogError("TMP nesnesi bulunamad�!");
        }
    }

    private IEnumerator DeactivateTMPAfterDelay(float delay)
    {
        // Belirtilen s�re kadar bekle
        yield return new WaitForSeconds(delay);

        // TMP nesnesini inaktif yap
        if (tmpObject != null)
        {
            tmpObject.gameObject.SetActive(false);
        }
    }
}
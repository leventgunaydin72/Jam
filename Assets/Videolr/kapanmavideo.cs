using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kapanmavideo : MonoBehaviour
{
    public float delay = 8.7f;

    void Start()
    {
        StartCoroutine(DisableAfterDelay(delay));
    }

    IEnumerator DisableAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
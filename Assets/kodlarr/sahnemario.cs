using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sahnemario : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Çarpýþtýðýmýz nesnenin etiketini kontrol ediyoruz
        if (collision.gameObject.tag == "Player")
        {
            // Geçiþ yapmak istediðiniz sahne adýný "NextScene" yerine yazýn
            SceneManager.LoadScene("mario");
        }
    }
}
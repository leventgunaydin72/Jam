using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sahnemario : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �arp��t���m�z nesnenin etiketini kontrol ediyoruz
        if (collision.gameObject.tag == "Player")
        {
            // Ge�i� yapmak istedi�iniz sahne ad�n� "NextScene" yerine yaz�n
            SceneManager.LoadScene("mario");
        }
    }
}
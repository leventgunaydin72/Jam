// 2024-05-20 AI-Tag 
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class snake1 : MonoBehaviour
{
    public Transform segmentPrefab;
    public Vector2Int direction = Vector2Int.right;
    public float speed = 20f;
    public float speedMultiplier = 1f;
    public int initialSize = 4;
    public bool moveThroughWalls = false;
    public Text lossText;
    public Text winText;
    public int countdown = 10; // Geri say�m i�in yeni de�i�ken
    public Text countdownText; // Geri say�m�n g�sterilece�i metin nesnesi i�in referans

    private List<Transform> segments = new List<Transform>();
    private Vector2Int input;
    private float nextUpdate;

    private void Start()
    {
        ResetState();
        countdownText.text = countdown.ToString(); // Oyun ba�lad���nda geri say�m� g�ster
    }

    private void Update()
    {
        if (direction.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                input = Vector2Int.up;
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                input = Vector2Int.down;
            }
        }
        else if (direction.y != 0f)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                input = Vector2Int.right;
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                input = Vector2Int.left;
            }
        }
    }

    private void FixedUpdate()
    {
        if (Time.time < nextUpdate)
        {
            return;
        }

        if (input != Vector2Int.zero)
        {
            direction = input;
        }

        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        int x = Mathf.RoundToInt(transform.position.x) + direction.x;
        int y = Mathf.RoundToInt(transform.position.y) + direction.y;
        transform.position = new Vector2(x, y);

        nextUpdate = Time.time + (1f / (speed * speedMultiplier));
    }

    public void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);

        countdown--; // Segment her b�y�d���nde geri say�m� 1 azalt
        countdownText.text = countdown.ToString(); // G�ncellenmi� geri say�m� g�ster

        if (countdown == 0) // Geri say�m 0'a ula�t���nda bir sonraki seviyeye ge�
        {
            winText.text = "Kazand�n";
            StartCoroutine(LoadSceneWithDelay("home3", 0.5f));
        }
    }

    private IEnumerator LoadSceneWithDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (countdown == 0) // Geri say�m 0 ise sahneyi de�i�tir
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void ResetState()
    {
        direction = Vector2Int.right;
        transform.position = Vector3.zero;

        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }

        segments.Clear();
        segments.Add(transform);

        for (int i = 0; i < initialSize - 1; i++)
        {
            Grow();
        }

        countdown = 10; // Oyun s�f�rland���nda geri say�m� 10'a s�f�rla
        countdownText.text = countdown.ToString(); // S�f�rlanm�� geri say�m� g�ster
        winText.text = ""; // Oyun s�f�rland���nda kazanma metnini s�f�rla
    }

    public bool Occupies(int x, int y)
    {
        foreach (Transform segment in segments)
        {
            if (Mathf.RoundToInt(segment.position.x) == x &&
                Mathf.RoundToInt(segment.position.y) == y)
            {
                return true;
            }
        }

        return false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            Grow();
        }
        else if (other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("Wall"))
        {
            ResetState();
            StartCoroutine(ShowLossMessage(0.1f));
        }
    }

    private IEnumerator ShowLossMessage(float delay)
    {
        yield return new WaitForSeconds(delay);
        lossText.text = "Tekrar Dene";
        yield return new WaitForSeconds(0.5f);
        lossText.text = "";
    }
}

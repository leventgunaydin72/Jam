using UnityEngine;

public class rakp : MonoBehaviour
{
    // Minimum ve maksimum hareket h�z�
    public float minSpeed = 1f;
    public float maxSpeed = 3f;

    // Yukar� ve a�a�� limitler
    public float upperLimit = 4f;
    public float lowerLimit = -4f;

    // Hareket h�z�
    private float moveSpeed;

    // Hareket y�n�
    private int direction = 1;

    // Rastgele y�n de�i�tirme zaman aral���
    private float changeDirectionTime;
    private float timer;

    void Start()
    {
        // Ba�lang�� h�z�n� rastgele belirle
        moveSpeed = Random.Range(minSpeed, maxSpeed);

        // �lk y�n de�i�tirme zaman�n� belirle
        SetRandomDirectionChangeTime();
    }

    void Update()
    {
        // �ubu�un yeni y pozisyonunu hesapla
        float newY = transform.position.y + direction * moveSpeed * Time.deltaTime;

        // Yukar� ve a�a�� limitlere �arpt���nda y�n de�i�tir
        if (newY > upperLimit)
        {
            newY = upperLimit;
            direction = -1;
            SetRandomDirectionChangeTime();
        }
        else if (newY < lowerLimit)
        {
            newY = lowerLimit;
            direction = 1;
            SetRandomDirectionChangeTime();
        }

        // Yeni pozisyonu ayarla
        transform.position = new Vector2(transform.position.x, newY);

        // Zamanlay�c�y� g�ncelle
        timer += Time.deltaTime;

        // Rastgele zaman aral�klar�nda y�n� de�i�tir ve yeni h�z belirle
        if (timer >= changeDirectionTime)
        {
            direction *= -1;
            moveSpeed = Random.Range(minSpeed, maxSpeed);
            SetRandomDirectionChangeTime();
        }
    }

    void SetRandomDirectionChangeTime()
    {
        changeDirectionTime = Random.Range(1f, 3f); // 1 ile 3 saniye aras�nda rastgele bir zaman belirle
        timer = 0f; // Zamanlay�c�y� s�f�rla
    }
}
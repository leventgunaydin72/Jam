using UnityEngine;

public class rakp : MonoBehaviour
{
    // Minimum ve maksimum hareket hýzý
    public float minSpeed = 1f;
    public float maxSpeed = 3f;

    // Yukarý ve aþaðý limitler
    public float upperLimit = 4f;
    public float lowerLimit = -4f;

    // Hareket hýzý
    private float moveSpeed;

    // Hareket yönü
    private int direction = 1;

    // Rastgele yön deðiþtirme zaman aralýðý
    private float changeDirectionTime;
    private float timer;

    void Start()
    {
        // Baþlangýç hýzýný rastgele belirle
        moveSpeed = Random.Range(minSpeed, maxSpeed);

        // Ýlk yön deðiþtirme zamanýný belirle
        SetRandomDirectionChangeTime();
    }

    void Update()
    {
        // Çubuðun yeni y pozisyonunu hesapla
        float newY = transform.position.y + direction * moveSpeed * Time.deltaTime;

        // Yukarý ve aþaðý limitlere çarptýðýnda yön deðiþtir
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

        // Zamanlayýcýyý güncelle
        timer += Time.deltaTime;

        // Rastgele zaman aralýklarýnda yönü deðiþtir ve yeni hýz belirle
        if (timer >= changeDirectionTime)
        {
            direction *= -1;
            moveSpeed = Random.Range(minSpeed, maxSpeed);
            SetRandomDirectionChangeTime();
        }
    }

    void SetRandomDirectionChangeTime()
    {
        changeDirectionTime = Random.Range(1f, 3f); // 1 ile 3 saniye arasýnda rastgele bir zaman belirle
        timer = 0f; // Zamanlayýcýyý sýfýrla
    }
}
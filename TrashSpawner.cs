// Файл: TrashSpawner.cs - клас, що відповідає за створення мусору у грі

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public GameObject[] trashPrefabs; // Масив префабів мусору
    public float spawnRate = 1f; // Швидкість генерації мусору
    private float nextSpawnTime = 0f; // Час до наступного створення мусору

    void Update()
    {
        // Перевірка, чи настав час створення нового об'єкта мусору
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + 1f / spawnRate; // Оновлення часу наступного створення
            SpawnTrash(); // Виклик методу для створення мусору
        }
    }

    void SpawnTrash()
    {
        // Визначення координати Y для появи мусору
        float spawnY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y + 1f;

        // Визначення випадкової позиції для появи мусору
        Vector2 spawnPosition = new Vector2(Random.Range(-2.5f, 2.5f), spawnY);

        // Вибір випадкового префаба мусору з масиву
        GameObject trashPrefab = trashPrefabs[Random.Range(0, trashPrefabs.Length)];

        // Створення об'єкту мусору на визначеній позиції з випадковим префабом
        GameObject trash = Instantiate(trashPrefab, spawnPosition, Quaternion.identity);

        // Отримання компонента Rigidbody2D об'єкту мусору
        Rigidbody2D rb = trash.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(0, -0.5f); // Встановлення швидкості руху мусору вниз
        }
    }
}

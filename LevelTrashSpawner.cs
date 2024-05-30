// Файл: LevelTrashSpawner.cs - клас, що відповідає за появу мусору на рівні

using UnityEngine;

public class LevelTrashSpawner : MonoBehaviour
{
    public static LevelTrashSpawner Instance { get; private set; } // Інстанс класу

    public GameObject[] trashPrefabs; // Масив префабів мусору для рівня

    private int trashSpawned; // Кількість створеного мусору
    private int trashCollected; // Кількість зібраного мусору
    private int trashMissed; // Кількість пропущеного мусору

    private float nextSpawnTime = 0f; // Час наступного створення мусору
    private LevelData currentLevelData; // Дані поточного рівня

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentLevelData = LevelManager.Instance.GetCurrentLevelData();
        trashSpawned = 0;
        trashCollected = 0;
        trashMissed = 0;
    }

    void Update()
    {
        if (trashSpawned < currentLevelData.trashCount && Time.time > nextSpawnTime)
        {
            // Якщо ще не всі мусорні об'єкти створені і час наступного створення настав
            nextSpawnTime = Time.time + 1f / currentLevelData.spawnRate;
            SpawnTrash();
        }
        else if (trashCollected + trashMissed >= currentLevelData.trashCount)
        {
            // Рівень завершено, коли всі мусорні об'єкти зібрані або пропущені
            LevelManager.Instance.CompleteLevel(trashCollected);
        }
    }

    void SpawnTrash()
    {
        // Визначення позиції появи мусору в зоні видимості камери
        float spawnY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y + 1f;
        Vector2 spawnPosition = new Vector2(Random.Range(-2.5f, 2.5f), spawnY);

        // Вибір префабу мусору для створення
        GameObject trashPrefab = trashPrefabs[Random.Range(0, trashPrefabs.Length)];

        // Створення мусорного об'єкту
        GameObject trash = Instantiate(trashPrefab, spawnPosition, Quaternion.identity);

        // Встановлення швидкості руху мусору
        Rigidbody2D rb = trash.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(0, -currentLevelData.trashSpeed);
        }

        // Інкрементування лічильника створеного мусору
        trashSpawned++;
    }

    // Метод для відзначення зібраного мусору
    public void TrashCollected()
    {
        trashCollected++;
    }

    // Метод для відзначення пропущеного мусору
    public void TrashMissed()
    {
        trashMissed++;
    }
}

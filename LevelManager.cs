// Файл: LevelManager.cs - клас, що відповідає за управління рівнями

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public LevelData[] levels;   // Масив усіх рівнів
    private int currentLevelIndex;

    public static LevelManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Завантаження рівня за його індексом
    public void LoadLevel(int levelIndex)
    {
        if (levelIndex < 0 || levelIndex >= levels.Length)
        {
            Debug.LogError("Неправильний індекс рівня.");
            return;
        }
        currentLevelIndex = levelIndex;
        Time.timeScale = 1f; // Відновлення часу при завантаженні нового рівня
        SceneManager.LoadScene("LevelBase");
    }


    // Отримання даних поточного рівня
    public LevelData GetCurrentLevelData()
    {
        return levels[currentLevelIndex];
    }

    // Завершення рівня та розрахунок зірок
    public void CompleteLevel(int collectedTrash)
    {
        int starCount = CalculateStars(collectedTrash);
        StarManager.Instance.SaveStars(currentLevelIndex, starCount);

        // Показуємо панель завершення рівня через LevelCompletionManager
        LevelCompletionManager.Instance.ShowCompletionPanel(starCount);
    }

    // Розрахунок кількості зірок
    int CalculateStars(int collectedTrash)
    {
        LevelData levelData = GetCurrentLevelData();
        if (collectedTrash == levelData.trashCount)
            return 3;
        if (collectedTrash >= levelData.trashCount * 0.75f)
            return 2;
        if (collectedTrash > 0)
            return 1;
        return 0;
    }

}

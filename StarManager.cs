// Файл: StarManager.cs - клас, що відповідає за управління зірками в грі

using UnityEngine;

public class StarManager : MonoBehaviour
{
    public static StarManager Instance { get; private set; } // Єдиний екземпляр класу StarManager

    // Метод, який викликається при створенні об'єкта
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

    // Метод для відображення зірок
    public void DisplayStars(int starCount, SpriteRenderer[] stars)
    {
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].enabled = i < starCount; // Увімкнення або вимкнення зірок залежно від кількості
        }
    }

    // Метод для збереження кількості зірок для певного рівня
    public void SaveStars(int levelIndex, int starCount)
    {
        int savedStars = PlayerPrefs.GetInt("Level" + levelIndex, 0); // Отримання кількості зірок, які вже збережено
        if (starCount > savedStars)
        {
            PlayerPrefs.SetInt("Level" + levelIndex, starCount); // Збереження кількості зірок, якщо вони більше, ніж вже збережені
        }
    }

    // Метод для завантаження кількості зірок для певного рівня
    public int LoadStars(int levelIndex)
    {
        return PlayerPrefs.GetInt("Level" + levelIndex, 0); // Завантаження кількості зірок, або 0, якщо для даного рівня кількість зірок ще не була збережена
    }

    // Метод для скидання зірок для всіх рівнів
    public void ResetStars()
    {
        for (int i = 0; i < LevelManager.Instance.levels.Length; i++)
        {
            PlayerPrefs.DeleteKey("Level" + i); // Скидання кількості зірок для кожного рівня
        }
    }

    // Метод для встановлення кількості зірок 0 для всіх рівнів
    public void ResetStarsToZero()
    {
        for (int i = 0; i < LevelManager.Instance.levels.Length; i++)
        {
            PlayerPrefs.SetInt("Level" + i, 0); // Встановлення кількості зірок 0 для кожного рівня
        }
    }
}

// Файл: ScoreManager.cs - клас, що відповідає за управління рахунком гравця

using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance; // Інстанс ScoreManager
    private int score = 0; // Поточний рахунок гравця
    public TextMeshProUGUI scoreText; // Текстове поле для відображення рахунку

    // Властивість для доступу до єдиного екземпляру ScoreManager
    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ScoreManager>();
                if (instance == null)
                {
                    Debug.LogError("Екземпляр ScoreManager не знайдено в сцені.");
                }
            }
            return instance;
        }
    }

    private void Start()
    {
        GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
        UpdateScoreText();
    }

    // Метод для додавання очків до рахунку
    public void AddScore()
    {
        score++;
        UpdateScoreText();
    }

    // Метод для оновлення тексту рахунку на екрані
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    // Метод для збереження рекорду
    public void SaveRecord()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}

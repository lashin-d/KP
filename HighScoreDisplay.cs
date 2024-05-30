// HighScoreDisplay.cs - клас, що відповідає за відображення рекордного рахунку

using TMPro;
using UnityEngine;

public class HighScoreDisplay : MonoBehaviour
{
    // Посилання на компонент TextMeshProUGUI для відображення рекордного рахунку
    public TextMeshProUGUI highScoreText;

    // Викликається при запуску гри
    private void Start()
    {
        // Отримуємо рекордний рахунок з PlayerPrefs, якщо він є, в іншому випадку використовуємо значення за замовчуванням (0)
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        // Встановлюємо текст для відображення рекордного рахунку
        highScoreText.text = "Record Score: " + highScore.ToString();
    }
}

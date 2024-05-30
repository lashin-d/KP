// LevelCompletionManager.cs - клас, що відповідає за управління завершенням рівня

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletionManager : MonoBehaviour
{
    // Статичне посилання на екземпляр LevelCompletionManager для доступу з інших скриптів
    public static LevelCompletionManager Instance { get; private set; }

    // Панель завершення рівня
    public GameObject levelCompletionPanel;
    // Текст для відображення кількості зірок
    public TextMeshProUGUI starCountText;
    // Панель паузи
    public GameObject pausePanel;

    // Викликається при створенні об'єкта на сцені
    private void Awake()
    {
        // Встановлюємо посилання на екземпляр LevelCompletionManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Метод для відображення панелі завершення рівня
    public void ShowCompletionPanel(int starCount)
    {
        if (levelCompletionPanel != null)
        {
            // Увімкнення панелі завершення рівня
            levelCompletionPanel.SetActive(true);
            // Встановлення тексту для відображення кількості зірок
            starCountText.text = starCount + "/3";
            // Зупинка часу
            Time.timeScale = 0f;

            // Отримання всіх компонентів SpriteRenderer в дочірніх об'єктах панелі завершення рівня
            SpriteRenderer[] stars = levelCompletionPanel.GetComponentsInChildren<SpriteRenderer>();
            // Відображення зірок відповідно до кількості зірок, які заробив гравець
            StarManager.Instance.DisplayStars(starCount, stars);
        }
        else
        {
            Debug.LogError("LevelCompletionPanel is not assigned in the inspector.");
        }
    }

    // Метод для приховування панелі завершення рівня
    public void HideCompletionPanel()
    {
        if (levelCompletionPanel != null)
        {
            // Вимкнення панелі завершення рівня
            levelCompletionPanel.SetActive(false);
            // Відновлення часу
            Time.timeScale = 1f;
        }
    }

    // Метод для повернення до вибору рівня
    public void ReturnToLevelMenu()
    {
        // Відновлення часу перед поверненням до вибору рівня
        Time.timeScale = 1f;
        // Завантаження сцени Levels_menu
        SceneManager.LoadScene("Levels_menu");
    }

    // Метод для паузи гри
    public void PauseGame()
    {
        if (pausePanel != null)
        {
            // Увімкнення панелі паузи
            pausePanel.SetActive(true);
            // Зупинка часу
            Time.timeScale = 0f;
        }
        else
        {
            Debug.LogError("PausePanel is not assigned in the inspector.");
        }
    }

    // Метод для відновлення гри
    public void ResumeGame()
    {
        if (pausePanel != null)
        {
            // Вимкнення панелі паузи
            pausePanel.SetActive(false);
            // Відновлення часу
            Time.timeScale = 1f;
        }
    }
}

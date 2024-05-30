// GameManager.cs - клас, що відповідає за управління ігровим процесом

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Статичне посилання на екземпляр GameManager для доступу з інших скриптів
    public static GameManager Instance { get; private set; }

    // Прапорець для відстеження паузи в грі
    public static bool isPaused = false;

    // UI-об'єкти для меню паузи та завершення гри
    public GameObject pauseMenuUI;
    public GameObject gameOverMenuUI;

    // Викликається при створенні об'єкта на сцені
    private void Awake()
    {
        // Встановлюємо посилання на екземпляр GameManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Викликається при запуску гри
    void Start()
    {
        // Скидаємо прапорець паузи, встановлюємо нормальну швидкість часу і вимикаємо меню паузи та завершення гри
        isPaused = false;
        Time.timeScale = 1f;
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }
        if (gameOverMenuUI != null)
        {
            gameOverMenuUI.SetActive(false);
        }
    }

    // Викликається кожен кадр
    void Update()
    {
        // Перевіряємо натискання клавіші Esc для управління паузою
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Метод для відновлення гри
    public void Resume()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }
        Time.timeScale = 1f;
        isPaused = false;
    }

    // Метод для паузи гри
    public void Pause()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true);
        }
        Time.timeScale = 0f;
        isPaused = true;
    }

    // Метод для завантаження головного меню
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("main");
        isPaused = false;
    }

    // Метод для перезапуску гри
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isPaused = false;
    }

    // Метод для завершення гри
    public void GameOver()
    {
        ScoreManager.Instance.SaveRecord();
        if (gameOverMenuUI != null)
        {
            gameOverMenuUI.SetActive(true);
        }
        Time.timeScale = 0f;
    }

    // Метод для завантаження головного меню з меню завершення гри
    public void LoadMenuFromGameOver()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("main");
    }

    // Метод для перезапуску гри з меню завершення гри
    public void RestartFromGameOver()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

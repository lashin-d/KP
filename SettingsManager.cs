// Файл: SettingsManager.cs - клас, що відповідає за управління налаштуваннями гри

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public GameObject musicToggleButton; // Кнопка для перемикання музики
    public Sprite musicOnSprite; // Спрайт, коли музика увімкнена
    public Sprite musicOffSprite; // Спрайт, коли музика вимкнена
    public TextMeshProUGUI musicStatusText; // Текстове поле для відображення статусу музики (Увімк./Вимк.)

    private bool isMusicOn = true; // Змінна для зберігання статусу музики

    void Start()
    {
        // Ініціалізуємо стан кнопки та тексту
        UpdateMusicButtonSprite();
    }

    // Метод для перемикання стану музики
    public void ToggleMusic()
    {
        if (BackgroundMusic.instance == null || BackgroundMusic.instance.gameObject.GetComponent<AudioSource>() == null)
        {
            Debug.LogError("BackgroundMusic instance or AudioSource is missing.");
            return;
        }

        isMusicOn = !isMusicOn;
        BackgroundMusic.instance.gameObject.GetComponent<AudioSource>().mute = !isMusicOn;
        UpdateMusicButtonSprite();
    }

    // Оновлення спрайта кнопки та тексту стану музики
    private void UpdateMusicButtonSprite()
    {
        if (musicToggleButton == null || musicStatusText == null)
        {
            Debug.LogError("MusicToggleButton or MusicStatusText is not assigned in the inspector.");
            return;
        }

        Image buttonImage = musicToggleButton.GetComponent<Image>();
        if (buttonImage == null)
        {
            Debug.LogError("Image component on MusicToggleButton is missing.");
            return;
        }

        if (isMusicOn)
        {
            buttonImage.sprite = musicOnSprite;
            musicStatusText.text = "On"; // Оновлюємо текст
        }
        else
        {
            buttonImage.sprite = musicOffSprite;
            musicStatusText.text = "Off"; // Оновлюємо текст
        }
    }

    // Метод для відкриття посилання
    public void OpenLink(string url)
    {
        if (string.IsNullOrEmpty(url))
        {
            Debug.LogError("URL is null or empty.");
            return;
        }
        Application.OpenURL(url);
    }

    // Метод для скидання рекорду та зірок рівнів
    public void ResetHighScoreAndStars()
    {
        PlayerPrefs.DeleteKey("HighScore");
        Debug.Log("High score reset.");
        StarManager.Instance.ResetStarsToZero();
        Debug.Log("Level stars reset to zero.");
    }
}

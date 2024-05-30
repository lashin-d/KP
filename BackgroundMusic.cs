// BackgroundMusic.cs - клас, що відповідає за управління фоновою музикою в грі

using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    // Статична змінна для доступу до екземпляру BackgroundMusic з інших скриптів
    public static BackgroundMusic instance = null;

    // Метод, який викликається при створенні об'єкта на сцені
    void Awake()
    {
        // Якщо екземпляр BackgroundMusic ще не був створений
        if (instance == null)
        {
            // Зберігаємо цей екземпляр як основний і запобігаємо його знищенню під час завантаження нової сцени
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Якщо вже є інший екземпляр BackgroundMusic, знищуємо поточний об'єкт, щоб уникнути дублювання музики
            Destroy(gameObject);
        }
    }
}

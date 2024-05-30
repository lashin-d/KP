// Файл: StarButton.cs - клас, що відповідає за відображення кількості зірок на кнопці рівня

using UnityEngine;
using UnityEngine.UI;

public class StarButton : MonoBehaviour
{
    public Sprite zeroStarsSprite; // Спрайт для кнопки без зірок
    public Sprite oneStarSprite; // Спрайт для кнопки з однією зіркою
    public Sprite twoStarsSprite; // Спрайт для кнопки з двома зірками
    public Sprite threeStarsSprite; // Спрайт для кнопки з трьома зірками

    private SpriteRenderer buttonSpriteRenderer; // Компонент для відображення спрайту кнопки

    void Awake()
    {
        buttonSpriteRenderer = GetComponent<SpriteRenderer>(); // Отримуємо компонент SpriteRenderer
        if (buttonSpriteRenderer == null)
        {
            Debug.LogError($"No SpriteRenderer component found on {gameObject.name}."); // Перевіряємо, чи компонент існує
        }
    }

    // Метод для встановлення кількості зірок на кнопці
    public void SetStars(int starCount)
    {
        if (buttonSpriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component is missing."); // Перевіряємо наявність компонента SpriteRenderer
            return;
        }

        // Зміна спрайту кнопки в залежності від кількості зірок
        switch (starCount)
        {
            case 0:
                buttonSpriteRenderer.sprite = zeroStarsSprite;
                break;
            case 1:
                buttonSpriteRenderer.sprite = oneStarSprite;
                break;
            case 2:
                buttonSpriteRenderer.sprite = twoStarsSprite;
                break;
            case 3:
                buttonSpriteRenderer.sprite = threeStarsSprite;
                break;
            default:
                Debug.LogError("Invalid star count."); // Виведення помилки, якщо кількість зірок неправильна
                break;
        }
    }
}

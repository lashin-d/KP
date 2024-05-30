// Файл: LevelSelect.cs - клас, що відповідає за вибір рівнів

using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public GameObject[] levelButtons;   // Масив кнопок рівнів

    void Start()
    {
        // Цикл для ітерації по всіх кнопках рівнів
        for (int i = 0; i < levelButtons.Length; i++)
        {
            // Завантаження кількості зірок для даного рівня
            int starCount = StarManager.Instance.LoadStars(i);

            // Отримання компонента StarButton з кнопки рівня
            StarButton starButton = levelButtons[i].GetComponent<StarButton>();

            // Перевірка наявності компонента StarButton
            if (starButton != null)
            {
                // Встановлення кількості зірок на кнопці рівня
                starButton.SetStars(starCount);
            }
            else
            {
                // Виведення помилки, якщо компонент StarButton не знайдено на кнопці рівня
                Debug.LogError($"Компонент StarButton не знайдено на кнопці рівня {levelButtons[i].name}.");
            }
        }
    }
}

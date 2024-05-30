// Buttons.cs - клас, що відповідає за управління кнопками в грі

using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    // Спрайти для кнопок
    public Sprite layer_orange, layer_green;

    // Викликається при натисканні кнопки миші
    void OnMouseDown()
    {
        // Змінюємо спрайт кнопки на зелений
        GetComponent<SpriteRenderer>().sprite = layer_green;
    }

    // Викликається при відпусканні кнопки миші
    void OnMouseUp()
    {
        // Повертаємо початковий спрайт кнопки
        GetComponent<SpriteRenderer>().sprite = layer_orange;
    }

    // Викликається при відпусканні кнопки миші як при натисканні на кнопку
    void OnMouseUpAsButton()
    {
        // Визначаємо дію в залежності від імені кнопки
        switch (gameObject.name)
        {
            // Якщо натиснута кнопка "Play"
            case "Play":
                // Завантажуємо сцену "Menu_game"
                SceneManager.LoadScene("Menu_game");
                break;
            // Якщо натиснута кнопка "Setting"
            case "Setting":
                // Завантажуємо сцену "Setting"
                SceneManager.LoadScene("Setting");
                break;
            // Якщо натиснута кнопка "Exit"
            case "Exit":
                // Завершуємо додаток
                Application.Quit();
                break;
        }
    }
}

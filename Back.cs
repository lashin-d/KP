// Back.cs - клас, що відповідає за обробки натискань кнопок "Вихід з головного меню" і "Назад" в Unity

using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    // Метод, який викликається при відпусканні кнопки миші, коли курсор знаходиться над об'єктом
    void OnMouseUpAsButton()
    {
        // Вибір дії в залежності від назви об'єкта
        switch (gameObject.name)
        {
            // Якщо натиснута кнопка "Вихід з головного меню"
            case "ExitFromMain":
                // Завантажити сцену "main"
                SceneManager.LoadScene("main");
                break;
            // Якщо натиснута кнопка "Назад"
            case "Back":
                // Завантажити сцену "Menu_game"
                SceneManager.LoadScene("Menu_game");
                break;
        }
    }
}

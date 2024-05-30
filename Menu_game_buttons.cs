// Файл: Menu_game_buttons.cs - клас, що відповідає за обробку натискання кнопок у головному меню гри

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_game_buttons : MonoBehaviour
{
    // Метод, що викликається при відпусканні кнопки миші
    void OnMouseUpAsButton()
    {
        // Вибір дії залежно від назви кнопки
        switch (gameObject.name)
        {
            case "Levels_button":
                // Завантаження меню рівнів
                SceneManager.LoadScene("Levels_menu");
                break;
            case "Endless_button":
                // Завантаження безкінечної гри
                SceneManager.LoadScene("EndlessGame");
                break;
            case "Exit_from_Menu_game":
                // Вихід до головного меню
                SceneManager.LoadScene("main");
                break;
        }
    }
}

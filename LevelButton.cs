// LevelButton.cs - клас, що відповідає за управління кнопками рівнів

using UnityEngine;

public class LevelButton : MonoBehaviour
{
    // Індекс рівня, який буде завантажений при натисканні на кнопку
    public int levelIndex;

    // Викликається при відпусканні кнопки миші як при натисканні на кнопку
    void OnMouseUpAsButton()
    {
        // Завантажуємо рівень з вказаним індексом
        LevelManager.Instance.LoadLevel(levelIndex);
    }
}

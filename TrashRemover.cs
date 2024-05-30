// Файл: TrashRemover.cs - клас, що відповідає за видалення мусору, який виходить за межі екрана

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrashRemover : MonoBehaviour
{
    void Update()
    {
        // Визначення координати Y, за якою мусор буде видалений
        float removY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y - 1f;

        // Перевірка, чи вихід об'єкта мусору за межі екрана
        if (transform.position.y < removY)
        {
            // Якщо сцена "EndlessGame", викликаємо метод GameOver() у GameManager
            if (SceneManager.GetActiveScene().name == "EndlessGame")
            {
                GameManager.Instance.GameOver();
            }
            // Якщо сцена "LevelBase", викликаємо метод TrashMissed() у LevelTrashSpawner
            if (SceneManager.GetActiveScene().name == "LevelBase")
            {
                LevelTrashSpawner.Instance.TrashMissed();
            }
            Destroy(gameObject); // Видаляємо об'єкт мусору, щоб він більше не існував
        }
    }
}

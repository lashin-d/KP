// GarbageBin.cs - клас, що відповідає за управління мусорним баком

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GarbageBin : MonoBehaviour
{
    // Швидкість руху мусорного бака
    public float speed = 5f;
    // Мінімальні та максимальні значення координат по осях X та Y для обмеження руху мусорного бака
    public float minX = -2.5f;
    public float maxX = 2.5f;
    public float minY = -4f;
    public float maxY = 4f;

    private Vector2 touchPosition; // Позиція, куди натиснув гравець

    void Update()
    {
        // Перевіряємо, чи є дотики на екрані
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            // Якщо дотик почався або триває
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                // Отримуємо позицію дотику у світових координатах
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            }
        }

        // Викликаємо метод руху мусорного бака
        MoveGarbageBin();
    }

    void MoveGarbageBin()
    {
        // Рухаємо мусорний бак до позиції, куди натиснув гравець
        transform.position = Vector2.MoveTowards(transform.position, touchPosition, speed * Time.deltaTime);

        // Обмежуємо рух мусорного бака в межах minX, maxX, minY і maxY
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minX, maxX),
                                          Mathf.Clamp(transform.position.y, minY, maxY));
    }

    // Викликається при зіткненні з іншим колайдером
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trash"))
        {
            // Перевіряємо, що мусор доторкнувся верхньої частини мусорного бака
            if (collision.bounds.center.y > transform.position.y)
            {
                // Знищуємо мусор
                Destroy(collision.gameObject);

                // Збільшуємо рахунок
                ScoreManager.Instance.AddScore();

                // Якщо сцена - "LevelBase", викликаємо метод зменшення кількості мусору
                if (SceneManager.GetActiveScene().name == "LevelBase")
                {
                    LevelTrashSpawner.Instance.TrashCollected();
                }
            }
        }
    }
}

// LevelData.cs - клас, що відповідає за зберігання даних рівня

using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    public int trashCount;      // Кількість сміття, яке потрібно зібрати
    public float trashSpeed;    // Швидкість падіння сміття
    public float spawnRate;     // Частота появи сміття
}

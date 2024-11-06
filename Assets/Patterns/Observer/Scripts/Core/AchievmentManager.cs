using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    private int enemiesKilled = 0;
    private int coinsCollected = 0;

    private void OnEnable()
    {
        // Подписываемся на события
        GameEvents.OnEnemyKilled += OnEnemyKilled;
        GameEvents.OnCoinsCollected += OnCoinsCollected;
    }

    private void OnDisable()
    {
        // Отписываемся от событий
        GameEvents.OnEnemyKilled -= OnEnemyKilled;
        GameEvents.OnCoinsCollected -= OnCoinsCollected;
    }

    private void OnEnemyKilled(int enemyID)
    {
        enemiesKilled++;
        Debug.Log("Enemies killed: " + enemiesKilled);
        
        if (enemiesKilled >= 10)
        {
            UnlockAchievement("Master Hunter");
        }
    }

    private void OnCoinsCollected(int amount)
    {
        coinsCollected += amount;
        Debug.Log("Coins collected: " + coinsCollected);
        
        if (coinsCollected >= 100)
        {
            UnlockAchievement("Treasure Hunter");
        }
    }

    private void UnlockAchievement(string achievement)
    {
        Debug.Log("Achievement Unlocked: " + achievement);
        // Здесь можно добавить код для отображения достижения на экране, сохранения прогресса и т.д.
    }
}
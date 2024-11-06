using System;

public static class GameEvents
{
    // События для различных действий
    public static event Action<int> OnEnemyKilled;
    public static event Action<int> OnCoinsCollected;

    // Методы для вызова событий
    public static void EnemyKilled(int enemyID)
    {
        OnEnemyKilled?.Invoke(enemyID);
    }

    public static void CoinsCollected(int amount)
    {
        OnCoinsCollected?.Invoke(amount);
    }
}
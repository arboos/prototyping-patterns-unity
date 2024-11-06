using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyID;            // Уникальный идентификатор врага
    public float maxHealth = 50f;  // Максимальное здоровье врага
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    // Метод для получения урона
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log($"Enemy {enemyID} took {damage} damage. Current health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Метод, вызываемый при смерти
    private void Die()
    {
        Debug.Log($"Enemy {enemyID} has been killed.");
        GameEvents.EnemyKilled(enemyID); // Вызываем событие, уведомляя систему достижений
        Destroy(gameObject);             // Уничтожаем врага после смерти
    }
}
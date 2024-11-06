using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth = 100f;   // Максимальное здоровье игрока
    private float currentHealth;
    public float damage = 10f;       // Урон, который наносит игрок

    private void Start()
    {
        currentHealth = maxHealth;
    }

    // Метод для атаки врага
    public void Attack(Enemy enemy)
    {
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }

    // Метод для получения урона
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log($"Player took {damage} damage. Current health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died.");
        Destroy(gameObject);
    }

    // Метод для сбора монет
    public void CollectCoin(int amount)
    {
        GameEvents.CoinsCollected(amount); // Вызываем событие для системы достижений
        Debug.Log($"Player collected {amount} coins.");
    }
}
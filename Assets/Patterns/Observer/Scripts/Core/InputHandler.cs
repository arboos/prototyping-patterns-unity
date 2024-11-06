using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Rigidbody))]
public class InputHandler : MonoBehaviour
{
    public float moveSpeed = 5f;  // Скорость передвижения игрока
    public float attackRange = 2f; // Дистанция атаки

    private Player player;
    private Rigidbody rb;
    private Camera mainCamera;

    private void Start()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        HandleMovement();
        HandleAttack();
    }

    // Обработка передвижения игрока
    private void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // ось X (A и D или стрелки влево/вправо)
        float vertical = Input.GetAxisRaw("Vertical");     // ось Z (W и S или стрелки вверх/вниз)

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        rb.velocity = moveDirection * moveSpeed;
    }

    // Обработка атаки
    private void HandleAttack()
    {
        if (Input.GetMouseButtonDown(0))  // ЛКМ для атаки
        {
            // Проверяем, есть ли враг в пределах дистанции атаки
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, attackRange))
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    player.Attack(enemy);  // Атакуем врага, если он в зоне действия
                }
            }
        }
    }
}
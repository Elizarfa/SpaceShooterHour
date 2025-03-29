using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab; // Ссылка на префаб пули
    // public Transform firePoint;    // Ссылка на точку выстрела - временно убираем

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0f;
        }
        else
        {
            Debug.LogError("Rigidbody2D component not found on the Player object!");
        }
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical).normalized * moveSpeed;
        rb.linearVelocity = movement;

        // Обработка стрельбы (по нажатию клавиши Space)
        if (Input.GetButtonDown("Jump"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.Log("Shoot() method called");
        if (bulletPrefab != null)
        {
            Vector3 spawnPosition = transform.position + Vector3.up * 1f; // Создаем пулю немного выше игрока
            GameObject bulletInstance = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
            Debug.Log("Bullet instantiated: " + bulletInstance.name + " at " + bulletInstance.transform.position);
        }
        else
        {
            Debug.LogError("Bullet Prefab not assigned in PlayerController!");
        }
    }
}
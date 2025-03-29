using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Задаем случайное направление движения
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        rb.linearVelocity = randomDirection * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Астероид столкнулся с игроком!");
            // Здесь можно добавить логику для столкновения с игроком (например, игрок получает урон, игра заканчивается)
            Destroy(gameObject); // Уничтожаем астероид при столкновении с игроком (пока так)
        }
        else if (collision.gameObject.GetComponent<Projectile>())
        {
            Debug.Log("Астероид уничтожен!");
            Destroy(gameObject); // Уничтожаем астероид при столкновении с пулей
            Destroy(collision.gameObject); // Уничтожаем пулю
        }
    }
}
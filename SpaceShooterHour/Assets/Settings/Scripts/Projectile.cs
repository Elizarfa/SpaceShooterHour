using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed; // Движение вперед относительно направления объекта
        //Destroy(gameObject, 3f); // Уничтожить пулю через 3 секунды (чтобы не засорять сцену)
    }

    // Этот метод будет вызван при столкновении с другим коллайдером
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Здесь можно добавить логику столкновения (например, уничтожение врага)
        //Destroy(gameObject); // Уничтожить пулю при столкновении с чем-либо
    }
}
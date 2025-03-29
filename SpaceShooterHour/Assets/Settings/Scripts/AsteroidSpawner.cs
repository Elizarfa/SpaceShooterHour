using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab; // Префаб астероида
    public float spawnRate = 2f;      // Как часто спавнить астероиды (в секундах)
    public float spawnDistance = 15f; // Расстояние от центра экрана, где будут появляться астероиды

    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnAsteroid();
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }

    void SpawnAsteroid()
    {
        if (asteroidPrefab != null)
        {
            // Случайная точка на окружности за пределами экрана
            Vector2 spawnCircle = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 spawnPosition = new Vector3(spawnCircle.x, spawnCircle.y, 0f);

            // Создаем астероид
            Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Asteroid Prefab not assigned in AsteroidSpawner!");
        }
    }
}
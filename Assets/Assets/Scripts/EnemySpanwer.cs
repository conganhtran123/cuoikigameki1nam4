using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpanwer : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private BoxCollider2D spawnArea;
    private bool hasSpawned = false;

    void Awake()
    {
        // Nếu chưa gán trong Inspector thì tự lấy
        if (spawnArea == null)
            spawnArea = GetComponent<BoxCollider2D>();
    }

    Vector3 GetRandomPositionInBox()
    {
        Bounds b = spawnArea.bounds;

        float x = Random.Range(b.min.x, b.max.x);
        float y = Random.Range(b.min.y, b.max.y);

        return new Vector3(x, y, 0);
    }

    int GetRandomAmount()
    {
        return Random.Range(5, 10);  // 5–9 con
    }

    GameObject GetRandomEnemy()
    {
        int index = Random.Range(0, enemyPrefabs.Length);
        return enemyPrefabs[index];
    }

    void SpawnEnemies()
    {
        if (hasSpawned) return;

        int total = GetRandomAmount();

        for (int i = 0; i < total; i++)
        {
            Vector3 spawnPos = GetRandomPositionInBox();
            Instantiate(GetRandomEnemy(), spawnPos, Quaternion.identity);
        }

        hasSpawned = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SpawnEnemies();
        }
    }
}

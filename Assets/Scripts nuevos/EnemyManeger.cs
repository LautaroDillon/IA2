using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    private List<GameObject> enemies = new List<GameObject>();

    // Agregado para manejar enemigos
    public int TotalEnemies => enemies.Count; // Agregado básico para contar enemigos activos

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2f, 5f);
    }

    void SpawnEnemy()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        enemies.Add(enemy);
    }

    // LINQ: Filtrar enemigos con salud mayor a 0
    void Update()
    {
        var aliveEnemies = enemies.Where(e => e.GetComponent<EnemyHealth>().health > 0).ToList();
    }
}
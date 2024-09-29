using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class BombSystem : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform bombPoint;
    private float bombCooldown = 10f;
    private float currentCooldown = 0f;

    void Update()
    {
        if (Input.GetButtonDown("Fire2") && currentCooldown <= 0)
        {
            DropBomb();
            currentCooldown = bombCooldown;
        }
        currentCooldown -= Time.deltaTime;
    }

    void DropBomb()
    {
        GameObject bomb = Instantiate(bombPrefab, bombPoint.position, Quaternion.identity);
        var enemies = FindObjectsOfType<EnemyHealth>();

        // LINQ: Aplicar daño a todos los enemigos dentro del rango de la bomba
        var enemiesInRange = enemies.Where(e => Vector3.Distance(e.transform.position, bombPoint.position) < 5f);
        foreach (var enemy in enemiesInRange)
        {
            enemy.TakeDamage(100); // Ejemplo de daño
        }
    }
}

using UnityEngine;
using System.Linq;

public class CollisionManager : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HandleCollision(collision.gameObject);
        }
    }

    void HandleCollision(GameObject enemy)
    {
        var enemyHealth = enemy.GetComponent<EnemyHealth>();
        enemyHealth.TakeDamage(10);

        // LINQ: Encontrar el primer enemigo golpeado por la bala
        var firstHitEnemy = GameObject.FindGameObjectsWithTag("Enemy").FirstOrDefault();
        if (firstHitEnemy != null)
        {
            firstHitEnemy.GetComponent<EnemyHealth>().TakeDamage(20);
        }
    }
}

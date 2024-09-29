using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, IDamageable
{
    [SerializeField]
    protected int health;

    public virtual void TakeDamage(int damage)
    {
        health -= damage;

        if (health >= 0)
            Destroy(gameObject);
    }

}

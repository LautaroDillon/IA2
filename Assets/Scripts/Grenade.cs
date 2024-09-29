using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public List<GameObject> inRadiusTargets = new List<GameObject>();

    public Collider Radius;

    private float timer;

    public void Awake()
    {
        
    }

    public void Update()
    {
        timer -= 1.0f * Time.deltaTime;
    }

    public void Detonate()
    {
        IEnumerable<IDamageable> validTargets;

        validTargets = inRadiusTargets.OfType<IDamageable>();

        foreach(IDamageable element in validTargets)
        {
            element.TakeDamage();
        }

        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        inRadiusTargets.Add(other.gameObject);
    }
}

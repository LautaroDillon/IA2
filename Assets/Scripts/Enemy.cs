using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy : MonoBehaviour
{
    public float Life;
    public float maxVelocity;
    public float maxForce;
    Vector3 _velocity;
    public Transform[] waypoints;
    int _actualIndex;
    public float viewRadius;
    public float patrolingRadius;
    public bool hunting;
    public bool Patroling;
    public PLayer huntingTarget;
    void Start()
    {
        Patroling = true;
        hunting = false;

        waypoints = GetNodoCercanos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(float damage)
    {
        Life -= damage;
    }

    Vector3 Pursuit(Vector3 target)
    {
        return Seek(target);
    }

    Vector3 Seek(Vector3 target)
    {
        var desired = target - transform.position;
        desired.Normalize();
        desired *= maxVelocity;

        var steering = desired - _velocity;
        steering = Vector3.ClampMagnitude(steering, maxForce);

        return steering;
    }

    public void AddForce(Vector3 dir)
    {
        _velocity += dir;

        _velocity = Vector3.ClampMagnitude(_velocity, maxVelocity);
    }

    public Transform[] GetNodoCercanos()
    {
        var nodosCercanos = GameManager.Instance.waypoints.Where(x => (x.position - transform.position).magnitude <= patrolingRadius).OrderBy(x => x.position.x).OrderBy(x => x.position.y).ToArray();
        return nodosCercanos;
    }
}

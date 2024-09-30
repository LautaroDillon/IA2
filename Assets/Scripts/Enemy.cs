using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy : MonoBehaviour
{
    public float Life;
    public float Damage;
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
        if((huntingTarget.transform.position - transform.position).magnitude <= viewRadius)
        {
            Patroling = false;
            hunting = true;
        }
        if(Patroling == true)
        {
            Patrol();
        }
        if(hunting == true)
        {
            Follow();
        }
    }

    public void Follow()
    {
        AddForce(Pursuit(huntingTarget.transform.position));

        transform.position += _velocity * Time.deltaTime;
        transform.forward = _velocity;
    }
    public void Patrol()
    {
        AddForce(Seek(waypoints[_actualIndex].position));

        if (Vector3.Distance(transform.position, waypoints[_actualIndex].position) <= 0.3f)
        {
            _actualIndex++;

            if (_actualIndex >= waypoints.Length)
                _actualIndex = 0;
        }

        transform.position += _velocity * Time.deltaTime;
        transform.forward = _velocity;
    }
    public void takeDamage(float damage)
    {
        Life -= damage;
        if(Life <= 0)
        {
            OnDeath();
        }
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            other.GetComponent<PLayer>().TakeDamage(Damage);
            OnDeath();
           
        }
    }

    public void OnDeath()
    {
        GameManager.Instance.enemyammount--;
        Destroy(gameObject);   
    }
}

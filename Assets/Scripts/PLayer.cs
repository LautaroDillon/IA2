using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer : MonoBehaviour
{
    public float life;
    public float maxlife;
    public float Speed;

    public Bullet bullet;
    public Turret turret;
    
    void Start()
    {
        life = maxlife;
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        Move(horizontal, vertical);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlaceTurret();
        }
    }

    public void PlaceTurret()
    {
        Instantiate(turret, transform.position, transform.rotation);
    }
    public void Move(float horizontal, float vertical)
    {
        transform.position += new Vector3(horizontal, 0, vertical) * Speed * Time.deltaTime;
        transform.forward += new Vector3(horizontal, 0, vertical);
    }

    public void TakeDamage(float damage)
    {
        life -= damage;
        if(life <= 0)
        {
            OnDeath();
        }
    }
    public void OnDeath()
    {
        Destroy(gameObject);
        Debug.Log("Death");
    }

    public void Shoot()
    {
        Debug.Log("Entro");
        Instantiate(bullet, transform.position, transform.rotation);
    }
}

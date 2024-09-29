using UnityEngine;
using System.Linq;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public int maxAmmo = 10;
    private int currentAmmo;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && currentAmmo > 0)
        {
            Shoot();
            currentAmmo--;
        }

        // LINQ: Limitar la cantidad de balas disparadas
        var ammoRemaining = Enumerable.Range(1, maxAmmo).TakeWhile(a => a <= currentAmmo).ToList();
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}

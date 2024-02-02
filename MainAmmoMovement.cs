//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class MainAmmoMovement : MonoBehaviour
//{
//    public GameObject bulletPrefab;
//    public Transform firePoint;
//    public float bulletSpeed = 7.0f;
//    public float fireRate = 1.0f;
//    private float nextFireTime = 0.0f;
//    public GameObjectMovement targetObject;
//
//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
//        {
//            firePoint.position = targetObject.transform.position;
//            Shoot();
//            nextFireTime = Time.time + 1.0f / fireRate;
//        }
//    }   
//
//    void Shoot()
//    {
//        // Instantiate a bullet at the firePoint position and rotation
//        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
//
//        // Get the Rigidbody2D component of the bullet
//        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
//
//        // Set the bullet's velocity
//        rb.velocity = transform.up * bulletSpeed;
//
//        // Destroy the bullet after a certain time (adjust as needed)
//        Destroy(bullet, 1.48f);
//    }
//}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAmmoMovement : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float fireRate = 0.5f;
    private bool canShoot = true;

    public GameObjectMovement targetObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            firePoint.position = targetObject.transform.position;
            StartCoroutine(ShootWithDelay());
        }
    }

    IEnumerator ShootWithDelay()
    {
        canShoot = false;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * bulletSpeed;
        Destroy(bullet, 2f);
        yield return new WaitForSeconds(1.0f / fireRate);

        canShoot = true;
    }
}
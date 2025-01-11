using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    //public float shootForce = 1500f;
    //public float fireRate = 5f;

    //private float nextTimeToShoot = 0f;

    public float acceleration = 3f;
    public float initialVelocity = 2f;
    public float launchTime = 1f;


    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            Shoot();
            //nextTimeToShoot = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {

        //GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        //bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * shootForce;

        //Destroy(bullet, 5f);

        GameObject newBullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        Rigidbody rb = newBullet.GetComponent<Rigidbody>();


        if (rb != null)
        {
            float displacement = 0.5f * acceleration * launchTime * initialVelocity * launchTime;

            Vector3 launchDirection = bulletSpawn.forward * displacement;

            rb.velocity = launchDirection;

            rb.AddForce(launchDirection, ForceMode.Impulse);
        
        }
    }
}

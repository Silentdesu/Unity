using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePosition;
    [SerializeField] float bulletSpeed = 10;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation) as GameObject;
        bullet.GetComponent<Rigidbody2D>().velocity = firePosition.right * bulletSpeed;
        Destroy(bullet, 5);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shoot : MonoBehaviour
{
    SpriteRenderer sr;

    public float projectileSpeed;
    public Transform spawnPointRight;
    public Transform spawnPointLeft;

    public Projectile projectilePrefab;

    public UnityEvent OnProjectileSpawned;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if (projectileSpeed <= 0) projectileSpeed = 7.0f;

        if (!spawnPointLeft || !spawnPointRight || !projectilePrefab)
            Debug.Log("please set default values on " + gameObject.name);
    }

    public void Fire()
    {
        if (!sr.flipX)
        {
            Projectile curProjectile = Instantiate(projectilePrefab,
                spawnPointRight.position, spawnPointRight.rotation);
            curProjectile.speed = projectileSpeed;
        }
        else
        {
            Projectile curProjectile = Instantiate(projectilePrefab,
                spawnPointLeft.position, spawnPointLeft.rotation);
            curProjectile.speed = -projectileSpeed;
        }

        OnProjectileSpawned.Invoke();
    }
    public void Firing()
    {
        if (!sr.flipX)
        {
            Projectile curProjectile = Instantiate(projectilePrefab,
                spawnPointRight.position, spawnPointRight.rotation);
            curProjectile.speed = projectileSpeed;
        }
        else
        {
            Projectile curProjectile = Instantiate(projectilePrefab,
                spawnPointLeft.position, spawnPointLeft.rotation);
            curProjectile.speed = -projectileSpeed;
        }

        OnProjectileSpawned.Invoke();
    }
    public void RunGun()
    {
        if (!sr.flipX)
        {
            Projectile curProjectile = Instantiate(projectilePrefab,
                spawnPointRight.position, spawnPointRight.rotation);
            curProjectile.speed = projectileSpeed;
        }
        else
        {
            Projectile curProjectile = Instantiate(projectilePrefab,
                spawnPointLeft.position, spawnPointLeft.rotation);
            curProjectile.speed = -projectileSpeed;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime;
    public int damage;
    //This is meant to be modified by the object that is creating this projectile.
    //eg: the shoot class
    [HideInInspector]
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        if (lifetime <= 0) lifetime = 2.0f;

        if (damage <= 0) damage = 1;

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherCollider = collision.gameObject;


        if (collision.gameObject.CompareTag("Enemy") && CompareTag("PlayerProjectile"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player") && CompareTag("EnemyProjectile"))
        {
            GameManager.Instance.Lives--;
            Destroy(gameObject);
        }
    }
}

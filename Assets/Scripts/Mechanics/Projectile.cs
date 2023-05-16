using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime;
    //This is meant to be modified by the object that is creating this projectile.
    //eg: the shoot class
    [HideInInspector]
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        if (lifetime <= 0) lifetime = 2.0f;

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherCollider = collision.gameObject;

        if (otherCollider.name != "Player")
        {
            Destroy(gameObject);
        }

    }
}

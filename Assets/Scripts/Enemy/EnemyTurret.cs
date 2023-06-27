using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

[RequireComponent(typeof(Shoot))]
public class EnemyTurret : Enemy
{
    public float turretFireDistance;
    public float projectileFireRate;

    Shoot shootScript;
    float timeSinceLastFire = 0.0f;

    


    public override void Start()
    {
        base.Start();

        shootScript = GetComponent<Shoot>();
        shootScript.OnProjectileSpawned.AddListener(UpdateTimeSinceLastFire);
        if (projectileFireRate <= 0.0f)
            projectileFireRate = 2.0f;

        if (turretFireDistance <= 0.0f)
            turretFireDistance = 6.0f;

    }

    private void Update()
    {
        AnimatorClipInfo[] curClips = anim.GetCurrentAnimatorClipInfo(0);

        //GameManager.Instance;

        if (curClips.Length > 0 && curClips[0].clip.name != "Firing")
        {
            if (curClips[0].clip.name != "Firing")
            {
                if (GameManager.Instance.playerInstance)
                {
                    if (GameManager.Instance.playerInstance.transform.position.x > transform.position.x)
                        sr.flipX = false;
                    else
                        sr.flipX = true;
                }

                float distance = Vector2.Distance(GameManager.Instance.playerInstance.transform.position, transform.position);

                if (distance <= turretFireDistance)
                {
                    sr.color = Color.red;
                    if (Time.time >= timeSinceLastFire + projectileFireRate)
                    {
                        anim.SetTrigger("Firing");
                    }
                }
                else
                {
                    sr.color = Color.white;
                }
            }
        }

    }

    public override void Death()
    {
        Destroy(gameObject);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }

    void UpdateTimeSinceLastFire()
    {
        timeSinceLastFire = Time.time;
    }

    private void OnDestroy()
    {
        shootScript.OnProjectileSpawned.RemoveListener(UpdateTimeSinceLastFire);
    }
}

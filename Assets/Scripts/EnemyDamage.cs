using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] int hits = 5;
    [SerializeField] Collider body;
    [SerializeField] ParticleSystem hitParticles;
    [SerializeField] ParticleSystem deathParticle;


    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        
        if (hits <= 0)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        hitParticles.Play();
        hits = hits - 1;
    }

    private void KillEnemy()
    {
        var vfx = Instantiate(deathParticle, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(gameObject);
    }
}

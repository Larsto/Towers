using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] int hits = 5;
    [SerializeField] GameObject explotion;
    [SerializeField] Collider body;

    private void OnParticleCollision(GameObject other)
    {
        hits = hits - 1;
        if (hits <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        Instantiate(explotion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

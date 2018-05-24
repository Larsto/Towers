using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 10;
    [SerializeField] ParticleSystem projectile;

    Transform targetEnemy;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        SetTargetEnemy();

        if (targetEnemy)
        {
            LookAtEnemy();
            FireAtEnemy();
        }

        else
        {
            Shoot(false);
        }
        
	}


    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return;  }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var distToA = Vector3.Distance(transform.position, transformA.position);
        var distToB = Vector3.Distance(transform.position, transformB.position);

        if(distToA < distToB)
        {
            return transformA;
        }

        return transformB;

    }

    private void FireAtEnemy()
    {
        float distaceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distaceToEnemy <= attackRange)
        {
            Shoot(true);
        }

        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectile.emission;
        emissionModule.enabled = isActive;
    }

    private void LookAtEnemy()
    {
        float distaceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distaceToEnemy <= attackRange)
        {
            objectToPan.LookAt(targetEnemy);
        }
        else
        {
            //Do nothing
        }
    }
}

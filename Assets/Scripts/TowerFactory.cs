using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField] Tower towerPrefab;
    [SerializeField] int towerLimit = 5;


    public void AddTower(Waypoint baseWaypoint)
    {
        var towers = FindObjectsOfType<Tower>();
        int numTowers = towers.Length;

        if (numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower();
            Debug.Log("Too many towers!");
        }
    }

    private void MoveExistingTower()
    {
        
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        Debug.Log(gameObject.name + " You can place here!");
        Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint.isPlaceable = false;
    }
}

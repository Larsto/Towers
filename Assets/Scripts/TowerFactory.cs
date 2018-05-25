using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField] Tower towerPrefab;
    [SerializeField] int towerLimit = 5;
    [SerializeField] Transform towerParentTransform;

    Queue<Tower> towerQueue = new Queue<Tower>();
    

    public void AddTower(Waypoint baseWaypoint)
    {
   
        int numTowers = towerQueue.Count;
    //    var towers = FindObjectsOfType<Tower>();
    //    int numTowers = towers.Length;
        
        if (numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
            Debug.Log("Too many towers!");
        }
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParentTransform;
        baseWaypoint.isPlaceable = false;
        newTower.baseWaypoint = baseWaypoint;
        towerQueue.Enqueue(newTower);
    }

    private void MoveExistingTower(Waypoint newbaseWaypoint)
    {
        var oldTower = towerQueue.Dequeue();

        oldTower.baseWaypoint.isPlaceable = true;
        newbaseWaypoint.isPlaceable = false;

        oldTower.baseWaypoint = newbaseWaypoint;
        oldTower.transform.position = newbaseWaypoint.transform.position;
        towerQueue.Enqueue(oldTower);

        
    }
}

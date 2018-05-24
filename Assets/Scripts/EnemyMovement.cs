using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [SerializeField] List<Waypoint> path;
    // Use this for initialization
    void Start ()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
	}

    // Update is called once per frame
    void Update ()
    {
	
	}
    
    IEnumerator FollowPath(List<Waypoint> path)
    {
        Debug.Log("Starting patrol.");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1.5f);
        }
        Debug.Log("Ending patrol.");
    }

}

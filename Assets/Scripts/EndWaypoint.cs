using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndWaypoint : MonoBehaviour {

    [SerializeField] int playerHealt = 10;
    [SerializeField] int healtDecrease = 1;

    private void OnTriggerEnter(Collider other)
    {
        playerHealt = playerHealt - healtDecrease;
        Debug.Log("Took a hit!");

        if (playerHealt < 0)
        {
            Debug.Log("GameOver");
        }
    }
}

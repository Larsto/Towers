using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;
    [SerializeField] AudioClip placeSound;


    Vector2Int gridPos;

    const int gridSize = 10;
    // Use this for initialization
    void Start () {
		
	}

    public int GetGridsize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / 10f),
            Mathf.RoundToInt(transform.position.z / 10f)
        );
    }
	
	public void SetTopColor(Color color)
    {
       MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
       topMeshRenderer.material.color = color;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                GetComponent<AudioSource>().PlayOneShot(placeSound);
                FindObjectOfType<TowerFactory>().AddTower(this);
            }

            else
            {
                Debug.Log(gameObject.name + " Can't place here!");
            }
        }
    }

}

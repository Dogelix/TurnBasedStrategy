using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

public class GameTile : MonoBehaviour, ITile
{
    [SerializeField]
    private ETileType tileType;
    [SerializeField]
    private GameObject topOfTile;

    public ETileType TileType
    {
        get
        {
            return tileType;
        }
    }

    Vector3 ITile.TopLocation
    {
        get
        {
            return topOfTile.transform.position;
        }
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
}

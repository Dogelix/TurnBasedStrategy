using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

public class GameTile : MonoBehaviour, ITile
{
    [SerializeField]
    private ETileType tileType;

    public ETileType TileType
    {
        get
        {
            return tileType;
        }
    }

    Vector3 ITile.Location
    {
        get
        {
            return transform.position;
        }
    }
}

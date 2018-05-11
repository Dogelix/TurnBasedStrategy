using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilites
{
    public interface ITile
    {
        ETileType TileType { get; }
        Vector3 TopLocation { get; }
    }
}
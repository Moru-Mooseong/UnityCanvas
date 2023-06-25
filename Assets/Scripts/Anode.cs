using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anode
{
    public bool isWalkable;
    public int gridX;
    public int gridY;
    public int height;
    public Tile originTile;


    /// <summary>
    /// the actual Cost from start Node to this Node
    /// </summary>
    public int gCost;
    /// <summary>
    /// the estimated Cost frome this Node to end Node
    /// </summary>
    public int hCost;
    public int fCost => gCost + hCost;
    public Anode parentNode;



    public Anode(bool _isWalkable, int _gridX, int _gridY, int _height, Tile _originTile)
    {
        isWalkable = _isWalkable;
        gridX = _gridX;
        gridY = _gridY;
        height = _height;
        originTile = _originTile;
    }
}

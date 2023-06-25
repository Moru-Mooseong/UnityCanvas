using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class MapGenerator : MonoBehaviour
{

    public int x, y = 50;
    //origin prefap
    public GameObject origin;

    //2D array
    public Tile[,] tiles;

    void Start()
    {
        tiles = new Tile[50, 50];
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                GameObject obj = Instantiate(origin);
               obj.transform.position = new Vector3(i,0, j);
                var comp = obj.GetComponent<Tile>();
                comp.Init(i, j);
                tiles[i, j] = comp;
            }
        }
    }


    public List<Anode> GetNeighbour(Anode node)
    {

    }
}

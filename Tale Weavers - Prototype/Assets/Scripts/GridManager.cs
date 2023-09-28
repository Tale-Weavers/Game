using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    private Camera _camera;

    private Tile currentTile;

    private Tile[,] tiles;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        tiles = new Tile[10, 10];
        foreach (Tile cube in transform.GetComponentsInChildren<Tile>())
        {
            cube.Row = (int)Math.Truncate(cube.transform.position.z);
            cube.Col = (int)Math.Truncate(cube.transform.position.x);
            tiles[cube.Row, cube.Col] = cube;
        }
    }

}

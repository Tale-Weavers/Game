using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    public static GridManager instance;

    private Camera _camera;

    private Square currentTile;

    public Dictionary<Vector3, Square> map = new Dictionary<Vector3, Square>();

    [SerializeField] private Square[] _tiles;



    private void Awake()
    {
       if(instance !=null && instance != this)
        {
            Destroy(this.gameObject);

        }
        else
        {
            instance = this;
        }

    }


    private void Start()
    {
        Square tileAux;
        foreach (Square tile in _tiles)
        {
            map.Add(tile.transform.position, tile);
          
            map.TryGetValue(tile.transform.position, out tileAux);
        }
        GameManager.instance.StartCharacters();
    }

    public List<Square> GetAdjacents(Square init)
    {
        List<Square> list = new List<Square>(4);
        Square value;
        Vector3 initPosition= init.transform.position;

        map.TryGetValue(new Vector3(initPosition.x + 1, 0, initPosition.z), out value);
        
        if(value!= null && value.isWalkable) list.Add(value);

        map.TryGetValue(new Vector3(initPosition.x - 1, 0, initPosition.z), out value);
        if (value != null && value.isWalkable) list.Add(value);

        map.TryGetValue(new Vector3(initPosition.x, 0, initPosition.z + 1), out value);
        if (value != null && value.isWalkable) list.Add(value);

        map.TryGetValue(new Vector3(initPosition.x, 0, initPosition.z - 1), out value);
        if (value != null && value.isWalkable) list.Add(value);

        return list;
    }

    public Square LookForPlayer(Square init)
    {
        Square playerPos = null;
        Square value;
        Vector3 initPosition = init.transform.position;

        map.TryGetValue(new Vector3(initPosition.x + 1, 0, initPosition.z), out value);

        if (value != null && value.occupiedByPlayer) playerPos = value;

        map.TryGetValue(new Vector3(initPosition.x - 1, 0, initPosition.z), out value);
        if (value != null && value.occupiedByPlayer) playerPos = value;

        map.TryGetValue(new Vector3(initPosition.x, 0, initPosition.z + 1), out value);
        if (value != null && value.occupiedByPlayer) playerPos = value;

        map.TryGetValue(new Vector3(initPosition.x, 0, initPosition.z - 1), out value);
        if (value != null && value.occupiedByPlayer) playerPos = value;

        return playerPos;
    }


}

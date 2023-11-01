using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;

    private Camera _camera;

    private Square currentTile;

    public Dictionary<Vector3, Square> map = new Dictionary<Vector3, Square>();

    [SerializeField] private Square[] _tiles;

    private List<Square> areaToPaint = new();

    private void Awake()
    {
        if (instance != null && instance != this)
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
        Vector3 initPosition = init.transform.position;

        map.TryGetValue(new Vector3(initPosition.x + 1, 0, initPosition.z), out value);

        if (value != null && value.isWalkable) list.Add(value);

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

    public Square LookForFountain(Square init)
    {
        Square fountainPos = null;
        Square value;
        Vector3 initPosition = init.transform.position;

        map.TryGetValue(new Vector3(initPosition.x + 1, 0, initPosition.z), out value);

        if (value != null && value.isFountain) fountainPos = value;

        map.TryGetValue(new Vector3(initPosition.x - 1, 0, initPosition.z), out value);
        if (value != null && value.isFountain) fountainPos = value;

        map.TryGetValue(new Vector3(initPosition.x, 0, initPosition.z + 1), out value);
        if (value != null && value.isFountain) fountainPos = value;

        map.TryGetValue(new Vector3(initPosition.x, 0, initPosition.z - 1), out value);
        if (value != null && value.isFountain) fountainPos = value;

        return fountainPos;
    }

    public List<Square> LookForWoolBall(Square init)
    {
        List<Square> woolPos = new();
        Square value;
        Vector3 initPosition = init.transform.position;

        map.TryGetValue(new Vector3(initPosition.x + 1, 0, initPosition.z), out value);

        if (value != null && value.containsWool) woolPos.Add(value);

        map.TryGetValue(new Vector3(initPosition.x - 1, 0, initPosition.z), out value);
        if (value != null && value.containsWool) woolPos.Add(value);

        map.TryGetValue(new Vector3(initPosition.x, 0, initPosition.z + 1), out value);
        if (value != null && value.containsWool) woolPos.Add(value);

        map.TryGetValue(new Vector3(initPosition.x, 0, initPosition.z - 1), out value);
        if (value != null && value.containsWool) woolPos.Add(value);

        return woolPos;
    }

    public List<Square> GetAdjacentsNonWalkable(Square init)
    {
        List<Square> list = new List<Square>(4);
        Square value;
        Vector3 initPosition = init.transform.position;

        map.TryGetValue(new Vector3(initPosition.x + 1, 0, initPosition.z), out value);

        if (value != null) list.Add(value);

        map.TryGetValue(new Vector3(initPosition.x - 1, 0, initPosition.z), out value);
        if (value != null) list.Add(value);

        map.TryGetValue(new Vector3(initPosition.x, 0, initPosition.z + 1), out value);
        if (value != null) list.Add(value);

        map.TryGetValue(new Vector3(initPosition.x, 0, initPosition.z - 1), out value);
        if (value != null) list.Add(value);

        return list;
    }

    public void DrawRange(int idx, Square pos)
    {
        switch (idx)
        {
            case 0:
                areaToPaint.AddRange(GetAdjacentsNonWalkable(pos)); //Verde

                List<Square> firstAdjancents = new();
                foreach (Square square in areaToPaint)
                {
                    firstAdjancents.AddRange(GetAdjacentsNonWalkable(square));//Azul
                    square.OnRange();
                }

                List<Square> secondAdjacents = new();
                foreach (Square square in firstAdjancents)
                {
                    if (square != pos)
                    {
                        secondAdjacents.AddRange(GetAdjacentsNonWalkable(square));//Rojo
                        square.OnRange();
                    }
                }
                foreach (Square square in secondAdjacents)
                {
                    square.OnRange();
                }
                areaToPaint.AddRange(firstAdjancents);
                areaToPaint.AddRange(secondAdjacents);
                break;

            case 1:
                areaToPaint.AddRange(GetAdjacentsNonWalkable(pos));
                foreach (Square square in areaToPaint)
                {
                    square.OnRange();
                }

                break;
        }
    }

    public void CleanRange()
    {
        foreach (Square square in areaToPaint)
        {
            square.ClearRange();
        }
        areaToPaint.Clear();
    }
}
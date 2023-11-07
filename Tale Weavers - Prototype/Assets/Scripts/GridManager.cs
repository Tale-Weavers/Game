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

    public List<Square> GetMultipleAdjacents(Square init, int numberOfSquares)
    {
        int listSize = numberOfSquares * 4;
        List<Square> list = new List<Square>(listSize);
        Square value;
        Vector3 initPosition = init.transform.position;

        for (int i = 1; i <= numberOfSquares; i++)
        {
            map.TryGetValue(new Vector3(initPosition.x + i, 0, initPosition.z), out value);
            if (value != null && value.isWalkable) list.Add(value);
        }

        for (int i = 1; i <= numberOfSquares; i++)
        {
            map.TryGetValue(new Vector3(initPosition.x - i, 0, initPosition.z), out value);
            if (value != null && value.isWalkable) list.Add(value);
        }

        for (int i = 1; i <= numberOfSquares; i++)
        {
            map.TryGetValue(new Vector3(initPosition.x, 0, initPosition.z + i), out value);
            if (value != null && value.isWalkable) list.Add(value);
        }

        for (int i = 1; i <= numberOfSquares; i++)
        {
            map.TryGetValue(new Vector3(initPosition.x, 0, initPosition.z - i), out value);
            if (value != null && value.isWalkable) list.Add(value);
        }
        return list;
    }

    public List<Square> GetMultipleAdjacentsNonWalkable(Square init, int numberOfSquares)
    {
        int listSize = numberOfSquares * 4;
        List<Square> list = new List<Square>(listSize);
        Square value;
        Vector3 initPosition = init.transform.position;

        for (int i = 1; i <= numberOfSquares; i++)
        {
            map.TryGetValue(new Vector3(initPosition.x + i, 0, initPosition.z), out value);
            if (value != null) list.Add(value);
        }

        for (int i = 1; i <= numberOfSquares; i++)
        {
            map.TryGetValue(new Vector3(initPosition.x - i, 0, initPosition.z), out value);
            if (value != null) list.Add(value);
        }

        for (int i = 1; i <= numberOfSquares; i++)
        {
            map.TryGetValue(new Vector3(initPosition.x, 0, initPosition.z + i), out value);
            if (value != null)
                list.Add(value);
        }

        for (int i = 1; i <= numberOfSquares; i++)
        {
            map.TryGetValue(new Vector3(initPosition.x, 0, initPosition.z - i), out value);
            if (value != null)
                list.Add(value);
        }
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

    public List<Square> GetDiagonalsNonWalkable(Square init, int numberOfSquares)
    {
        List<Square> list = new List<Square>();
        Square value;
        Vector3 initPosition = init.transform.position;

        for (int i = 1; i <= numberOfSquares; i++)
        {
            map.TryGetValue(new Vector3(initPosition.x + i, 0, initPosition.z + i), out value);
            if (value != null) list.Add(value);
        }

        for (int i = 1; i <= numberOfSquares; i++)
        {
            map.TryGetValue(new Vector3(initPosition.x - i, 0, initPosition.z - i), out value);
            if (value != null) list.Add(value);
        }

        for (int i = 1; i <= numberOfSquares; i++)
        {
            map.TryGetValue(new Vector3(initPosition.x - i, 0, initPosition.z + i), out value);
            if (value != null) list.Add(value);
        }

        for (int i = 1; i <= numberOfSquares; i++)
        {
            map.TryGetValue(new Vector3(initPosition.x + i, 0, initPosition.z - i), out value);
            if (value != null) list.Add(value);
        }
        return list;
    }

    public void DrawRange(int idx, Square pos)
    {
        switch (idx)
        {
            case 0:
                #region Version Antigua
                //areaToPaint.AddRange(GetAdjacentsNonWalkable(pos)); //Verde

                //List<Square> firstAdjancents = new();
                //foreach (Square square in areaToPaint)
                //{
                //    firstAdjancents.AddRange(GetAdjacentsNonWalkable(square));//Azul

                //}

                //List<Square> secondAdjacents = new();
                //foreach (Square square in firstAdjancents)
                //{
                //    if (square != pos)
                //    {
                //        secondAdjacents.AddRange(GetAdjacentsNonWalkable(square));//Rojo

                //    }
                //}
                //areaToPaint.AddRange(firstAdjancents);
                //areaToPaint.AddRange(secondAdjacents);
                #endregion
                List<Square> firstAdjancents = new();
                areaToPaint.AddRange(GetMultipleAdjacentsNonWalkable(pos, 3));

                foreach (Square square in areaToPaint)
                {
                    firstAdjancents.AddRange(GetAdjacentsNonWalkable(square));//Azul
                }
                areaToPaint.AddRange(GetDiagonalsNonWalkable(pos, 2));
                areaToPaint.AddRange(firstAdjancents);
                foreach (Square square in areaToPaint)
                {
                    if (Mathf.Abs(pos.transform.position.x - square.transform.position.x) <= 3 && Mathf.Abs(pos.transform.position.z - square.transform.position.z) <= 3)
                        square.OnRange();
                }
                break;

            case 1:
                areaToPaint.AddRange(GetAdjacentsNonWalkable(pos));
                foreach (Square square in areaToPaint)
                {
                        square.OnRange();
                }
                break;

            case 2:
                areaToPaint.AddRange(GetMultipleAdjacents(pos, 3));
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
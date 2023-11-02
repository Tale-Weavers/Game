using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public bool isWalkable;

    public bool isFountain;

    public bool containsWool;

    public bool isDoor;
    public bool containsButton;

    [SerializeField] private int _fountainCounter;

    public bool isExit = false;

    public bool isHidingSpot = false;

    public bool occupiedByPlayer;

    private bool _drawingrange;

    [SerializeField] private bool isAdjacent;

    private Material currentMaterial;

    private Color _colorInit;
    public WoolBall wool;
    public Square door;

    public void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        currentMaterial = renderer.material;
        if (isHidingSpot) currentMaterial.color = Color.magenta;
        if (isExit) currentMaterial.color = Color.cyan;
        if (isFountain) { currentMaterial.color = Color.blue; isWalkable = false; }
        if (isDoor) { currentMaterial.color = Color.yellow; isWalkable = false; }
        if (containsButton) currentMaterial.color = Color.red;
        _colorInit = currentMaterial.color;

        if (containsWool)
        {
            WoolBall[] woolballList;
            woolballList = FindObjectsByType<WoolBall>(FindObjectsSortMode.None);
            foreach (WoolBall woolball in woolballList)
            {
                if (woolball.tile = this) wool = woolball;
            }
        }
    }

    private void Update()
    {
    }

    public List<Square> SeeNeighbours()
    {
        List<Square> list = new List<Square>();
        list = GridManager.instance.GetAdjacents(this);
        return list;
    }

    public List<Square> SeeWool()
    {
        List<Square> list = new List<Square>();
        list = GridManager.instance.LookForWoolBall(this);
        return list;
    }

    private void OnMouseEnter()
    {
        if (isAdjacent || _drawingrange)
        {
            currentMaterial.color = Color.green;
        }
    }

    private void OnMouseExit()
    {
        if (!_drawingrange)
        {
            currentMaterial.color = _colorInit;
        }
        else
        {
            currentMaterial.color = Color.black;
        }
    }

    public void SetAdjacent(bool adjacent)
    {
        isAdjacent = adjacent;

        if (!isAdjacent)
        {
            currentMaterial.color = _colorInit;
        }
    }

    public bool DecreaseFountainCounter()
    {
        if (_fountainCounter > 0)
        {
            _fountainCounter--;
            return true;
        }
        else return false;
    }

    public void OnRange()
    {
        _drawingrange = true;
        currentMaterial.color = Color.black;
    }

    public void ClearRange()
    {
        currentMaterial.color = _colorInit;
        _drawingrange = false;
    }

    public void OpenDoor()
    {
        door.isWalkable = true;
        door.currentMaterial.color = Color.grey;
        containsButton = false;
    }
}
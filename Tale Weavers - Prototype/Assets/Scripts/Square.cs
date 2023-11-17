using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public bool isWalkable;

    public bool isFountain;

    public bool containsWool;
    public bool containsFlashlight;
    public bool isDoor;
    public bool containsButton;
    public bool isOilPuddle;

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

    [SerializeField] private Material _initMaterial;
    [SerializeField] private Material _rangeMaterial;
    [SerializeField] private Material _selectedMaterial;
    [SerializeField] private Material emptyFountainMaterial;
    [SerializeField] private GameObject _fountainObject;

    private Renderer renderer;

    public void Start()
    {
        renderer = GetComponent<Renderer>();
        currentMaterial = renderer.material;
        //if (isHidingSpot) currentMaterial.color = Color.magenta;
        //if (isExit) currentMaterial.color = Color.cyan;
        if (isFountain) {  isWalkable = false; }
        if (isDoor) {  isWalkable = false; }
        //if (containsButton) currentMaterial.color = Color.red;
        //if (isOilPuddle) currentMaterial.color = new Color(0.43f, 0.29f, 0.11f);
        //if (containsFlashlight) currentMaterial.color = new Color(0.43f, 0.82f, 0.51f);
        //_colorInit = currentMaterial.color;

        //if (containsWool)
        //{
        //    WoolBall[] woolballList;
        //    woolballList = FindObjectsByType<WoolBall>(FindObjectsSortMode.None);
        //    foreach (WoolBall woolball in woolballList)
        //    {
        //        if (woolball.tile = this) wool = woolball;
        //    }
        //}
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
        if (isAdjacent && !_drawingrange)
        {
            renderer.material = _selectedMaterial;
        }
    }

    private void OnMouseExit()
    {
        if (!_drawingrange)
        {
            renderer.material = _initMaterial;
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
            if(_fountainCounter == 0)
            {
                _fountainObject.GetComponentInChildren<Renderer>().material = emptyFountainMaterial;
            }
            return true;
        }
        else return false;
    }

    public void OnRange()
    {
        _drawingrange = true;
        renderer.material = _rangeMaterial;
    }

    public void ClearRange()
    {
        renderer.material = _initMaterial;
        _drawingrange = false;
    }

    public void OpenDoor()
    {
        door.isWalkable = true;
        door.currentMaterial.color = Color.grey;
        containsButton = false;
    }
}
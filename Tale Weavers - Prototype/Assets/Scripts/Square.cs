using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Square : MonoBehaviour
{

    public bool isWalkable;
    public bool occupiedByPlayer;

    [SerializeField] private bool isAdjacent;

    private Material currentMaterial;

    private Color _colorInit;


    public void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        currentMaterial = renderer.material;
        _colorInit = currentMaterial.color;
       
    }

    private void Update()
    {
        
    }

    public List<Square> SeeNeighbours()
    {
        List <Square> list = new List<Square>();
        list = GridManager.instance.GetAdjacents(this);
        return list;
    }

    private void OnMouseEnter()
    {
        if (isAdjacent)
        {
            currentMaterial.color = Color.green;
        }
    }

    private void OnMouseExit()
    {
        currentMaterial.color = _colorInit;
    }

    public void SetAdjacent(bool adjacent)
    {
        isAdjacent = adjacent;

        if (!isAdjacent)
        {
            currentMaterial.color = _colorInit;
        }

    }







}

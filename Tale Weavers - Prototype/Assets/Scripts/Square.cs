using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Square : MonoBehaviour
{

    public bool isWalkable;

    [SerializeField] private bool isAdjacent;

    private Material currentMaterial;

    private Color colorInit;


    public void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        currentMaterial = renderer.material;
        colorInit = currentMaterial.color;
       
    }

    void Update()
    {
        
    }

    public List<Square> seeNeighbours()
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
        
        currentMaterial.color = colorInit;
    }

    public void SetAdjacent(bool adjacent)
    {
        isAdjacent = adjacent;
    }







}

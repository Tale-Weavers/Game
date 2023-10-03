using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MoveableCharacter
{
    public Transform inspectorFacingDir;
    protected Vector3 facingDirection;

    public Transform[] directions;
    protected List<Vector3> realDirections = new();

    // Start is called before the first frame update
    protected void Start()
    {
        foreach (var direction in directions)
        {
            realDirections.Add(direction.position);
        }

        facingDirection = inspectorFacingDir.position;

    }

    // Update is called once per frame
    void Update()
    {
        
        //if (Input.GetMouseButtonUp(1) && currentTurn == GameManager.instance.currentTurn)
        //{
        //    MoveCharacter();
        //}
    }

    //Método para hacer el simulacro de movimiento de enemigos antes de implementar la IA de su comportamiento
    //private void MoveCharacter()
    //{
    //    Vector3 mousePosition = Input.mousePosition;

    //    Ray ray = Camera.main.ScreenPointToRay(mousePosition);

    //    RaycastHit hit;

    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        if (walkablePositions.Contains(hit.transform.GetComponent<Square>()))
    //        {
    //            transform.position = new Vector3(hit.transform.position.x, transform.position.y, hit.transform.position.z);
    //            currentPos = hit.transform.GetComponent<Square>();
    //            MoveablePositions();
    //            GameManager.instance.NextTurn();
    //            currentTurn++;
    //        }
    //    }
    //}

    public abstract void StartAction();

    public void CheckVision()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position, facingDirection*3.5f, Color.red, 0.5f);

        if (Physics.Raycast(transform.position, facingDirection, out hit, 3.5f)) 
        {
            if(hit.collider.CompareTag("Player")) 
            {
                Debug.Log("Atrapada");
            }
        }
    }

}

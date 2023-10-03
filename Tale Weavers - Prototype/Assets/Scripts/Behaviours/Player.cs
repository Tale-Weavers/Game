using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MoveableCharacter
{


    // Start is called before the first frame update
    private void Start()
    {



    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && currentTurn == GameManager.instance.currentTurn)
        {
            MoveCharacter();
        }

        if(Input.GetKeyDown(KeyCode.Y)) { GameManager.instance.EndPlayerTurn(); currentTurn++; } //For debugging purposes, temporal
    }


    private void MoveCharacter()
    {

        Vector3 mousePosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (walkablePositions.Contains(hit.transform.GetComponent<Square>()))
            {
                transform.position = new Vector3(hit.transform.position.x, transform.position.y, hit.transform.position.z);
                Square target = hit.transform.GetComponent<Square>();
                currentPos.isWalkable = true;
                currentPos = target;
                target.isWalkable = false;
                GameManager.instance.EndPlayerTurn();
                currentTurn++;
            }
        }
    }
    public void UpdateMoveable()
    {
        MoveablePositions();
    }

}


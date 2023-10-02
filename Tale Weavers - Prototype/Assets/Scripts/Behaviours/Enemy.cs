using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MoveableCharacter
{
    // Start is called before the first frame update
    void Start()
    {
        
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

    public void StartMovement()
    {
        MoveablePositions();
        int random = Random.Range(0, walkablePositions.Count);
        transform.position = new Vector3(walkablePositions[random].transform.position.x, transform.position.y, walkablePositions[random].transform.position.z);
        currentPos.isWalkable = true;
        currentPos = walkablePositions[random].transform.GetComponent<Square>();
        currentPos.isWalkable = false;
    }
}

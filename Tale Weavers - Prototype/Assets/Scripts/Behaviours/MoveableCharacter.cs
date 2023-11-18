using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableCharacter : MonoBehaviour
{
    protected List<Square> walkablePositions = new List<Square>();

    public Square initSpawn;
    public Square currentPos;

    public bool moveDone = false;



    protected int currentTurn;

    protected void Awake()
    {
        currentPos = initSpawn;
        MoveablePositions();
        currentTurn = 0;
        initSpawn.isWalkable = false;
    }

    protected void MoveablePositions()
    {
        if (walkablePositions.Count > 0)
        {
            if (gameObject.CompareTag("Player"))
            {
                foreach (Square square in walkablePositions)
                {
                    square.SetAdjacent(false);
                }
            }
        }


        walkablePositions = currentPos.SeeNeighbours();

        if (gameObject.CompareTag("Player"))
        {
            foreach (Square square in walkablePositions)
            {
                square.SetAdjacent(true);
            }
        }
    }
}

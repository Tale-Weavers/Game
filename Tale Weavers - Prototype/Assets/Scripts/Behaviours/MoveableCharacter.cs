using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableCharacter : MonoBehaviour
{
    protected List<Square> walkablePositions = new List<Square>();

    public Square initSpawn;
    public Square currentPos;

    protected Material currentMaterial;

    protected int currentTurn;

    protected void Awake()
    {
        currentPos = initSpawn;
        transform.position = new Vector3(currentPos.transform.position.x, transform.position.y, currentPos.transform.position.z);
        MoveablePositions();
        currentTurn = 0;
        initSpawn.isWalkable = false;

        Renderer renderer = GetComponent<Renderer>();
        currentMaterial = renderer.material;
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

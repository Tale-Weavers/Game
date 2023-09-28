using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    List<Square> walkablePositions = new List<Square>();
    public Square initSpawn;

    public Square currentPos;


    // Start is called before the first frame update
    void Start()
    {


        
    }

    

    private void Awake()
    {
        currentPos = initSpawn;
        moveablePositions();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePosition = Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (walkablePositions.Contains(hit.transform.GetComponent<Square>()))
                {
                    transform.position = new Vector3 (hit.transform.position.x,transform.position.y,hit.transform.position.z);
                    currentPos = hit.transform.GetComponent<Square>();
                    moveablePositions();
                }
            }
        }
    }

    void moveablePositions()
    {
        if(walkablePositions.Count > 0)
        {

            foreach (Square square in walkablePositions)
            {
                square.SetAdjacent(false);
            }
        }


        walkablePositions = currentPos.seeNeighbours();

        foreach (Square square in walkablePositions)
        {
            square.SetAdjacent(true);
        }
    }

        


 
}

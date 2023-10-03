using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void StartAction()
    {
        CheckVision();
        MoveablePositions();
        int random = Random.Range(0, walkablePositions.Count);
        Vector3 lastPosition = transform.position;
        transform.position = new Vector3(walkablePositions[random].transform.position.x, transform.position.y, walkablePositions[random].transform.position.z);
        currentPos.isWalkable = true;
        currentPos = walkablePositions[random].transform.GetComponent<Square>();
        currentPos.isWalkable = false;
        //cambiar facing dir
        facingDirection = transform.position - lastPosition;
        CheckVision();
    }


}

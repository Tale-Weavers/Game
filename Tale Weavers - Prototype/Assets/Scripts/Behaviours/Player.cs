using UnityEngine;

public class Player : MoveableCharacter
{
    [SerializeField] private bool _isSeen;

    public bool actionDone = false;
    public bool moveDone = false;

    // Start is called before the first frame update
    private void Start()
    {
    }

    private void Awake()
    {
        base.Awake();
        currentPos.occupiedByPlayer = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && currentTurn == GameManager.instance.currentTurn)
        {
            MoveCharacter();
        }

        if (Input.GetKeyDown(KeyCode.Y)) { GameManager.instance.EndPlayerTurn(); currentTurn++; } //For debugging purposes, temporal

        if (Input.GetKeyDown(KeyCode.X)&&!_isSeen) { KnockOutEnemies(); } //For debugging purposes, temporal
    }

    public void KnockOutEnemies()
    {
        if (_isSeen)
        {
            return;
        }
        if (GameManager.instance.CloseEnemies())
        {
            actionDone = true;
        }
    }

    public void SkipTurn()
    {
        GameManager.instance.EndPlayerTurn(); 
        currentTurn++;
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
                currentPos.occupiedByPlayer = false;
                currentPos = target;
                target.isWalkable = false;
                target.occupiedByPlayer = true;
                moveDone = true;
                if(currentPos.isExit)
                {
                    GameManager.instance.EndLevel();
                }
                //GameManager.instance.EndPlayerTurn();
                //currentTurn++;
            }
        }
    }

    public void UpdateMoveable()
    {
        MoveablePositions();
    }

    public void Seen()
    {
        _isSeen = true;
    }

    public void NewTurn()
    {
    }
}
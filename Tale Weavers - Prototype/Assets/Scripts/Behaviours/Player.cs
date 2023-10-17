using UnityEngine;

public class Player : MoveableCharacter
{
    [SerializeField] private bool _isSeen;
    [SerializeField] public bool _isHiding;

    private Square fountain;

    public bool actionDone = false;

    public bool canSquawk = false;
    public bool fountainClose = false;

    // Start is called before the first frame update
    private void Start()
    {
    }

    private void Awake()
    {
        base.Awake();
        transform.position = new Vector3(currentPos.transform.position.x, transform.position.y, currentPos.transform.position.z);
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

        if (Input.GetKeyDown(KeyCode.X) && !_isSeen) { KnockOutEnemies(); } //For debugging purposes, temporal

        if (Input.GetKeyDown(KeyCode.S)) { Squawk(); } //For debugging purposes, temporal

        if (Input.GetKeyDown(KeyCode.D)) { Drink(); }
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
            UpdateMoveable();
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
                Square target = hit.transform.GetComponent<Square>();
                if (target.isHidingSpot)
                {
                    GameManager.instance.CheckEnemiesVision();
                }
                transform.position = new Vector3(hit.transform.position.x, transform.position.y, hit.transform.position.z);
                currentPos.isWalkable = true;
                currentPos.occupiedByPlayer = false;
                if (currentPos.isHidingSpot) _isHiding = false;
                currentPos = target;
                target.isWalkable = false;
                target.occupiedByPlayer = true;
                moveDone = true;

                fountain = GridManager.instance.LookForFountain(currentPos);
                if (fountain != null)
                {
                    fountainClose = true;
                    GameManager.instance.drinkButton.gameObject.SetActive(true);
                }
                else
                {
                    fountainClose = false;
                    GameManager.instance.drinkButton.gameObject.SetActive(false);
                }

                if (currentPos.isExit)
                {
                    GameManager.instance.EndLevel();
                }
                else if (currentPos.isHidingSpot)
                {
                    _isHiding = true;

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

    public void Seen(bool seen)
    {
        _isSeen = seen;
    }

    public void NewTurn()
    {
    }

    public void Squawk()
    {
        if (canSquawk)
        {
            GameManager.instance.PlayerSquawk();
            canSquawk = false;
        }
        else
        {
            Debug.Log("Tienes la garganta seca");
        }
    }

    public void Drink()
    {
        if (fountainClose && !canSquawk)
        {
            if (fountain.DecreaseFountainCounter())
            {
                canSquawk = true;
            }
            else
            {
                Debug.Log("Fuente Seca");
            }
        }
        else
        {
            Debug.Log("No hay agua cerca");
        }
    }
}
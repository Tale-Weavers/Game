using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MoveableCharacter, ISubject<bool>
{
    [SerializeField] private bool _isSeen;
    [SerializeField] private bool _isHiding = false;

    public bool IsHiding
    {
        get { return _isHiding; }

        set
        {
            _isHiding = value;
            NotifyObservers();
        }
    }

    public bool IsSeen
    {
        get { return _isSeen; }
        set
        {
            _isSeen = value;
            if (value && AudioManager.instance.IsPlaying("musicaNivel"))
            {
                AudioManager.instance.Stop("musicaNivel");
                AudioManager.instance.Play("musicaAtrapado");
            }
            else if (!value && AudioManager.instance.IsPlaying("musicaAtrapado"))
            {
                AudioManager.instance.Play("musicaNivel");
                AudioManager.instance.Stop("musicaAtrapado");
            }

        }
    }
    private Square fountain;

    public bool checkingRange;

    public bool actionDone = false;

    public bool canSquawk = false;
    public bool fountainClose = false;
    public bool hasWoolBall = false;
    public bool hasLaser = false;
    public bool hasFlashlight = false;

    private WoolBall _woolball;
    private WoolBall _laser;

    [SerializeField] private bool _placingWool;
    [SerializeField] private bool _placingLaser;
    [SerializeField] private bool _usingFlashlight;

    private List<IObserver<bool>> _boolObservers = new();

    private Animator animator;
    private bool moving;
    private bool sliding;
    private const float MOV_SPEED = 0.05f;
    private Vector3 target;

    public Transform inspectorFacingDir;
    protected Vector3 facingDirection;

    public Square lastPos;
    // Start is called before the first frame update
    private void Start()
    {
    }

    private void Awake()
    {
        base.Awake();
        transform.position = new Vector3(currentPos.transform.position.x, 0.5f, currentPos.transform.position.z);
        currentPos.occupiedByPlayer = true;
        animator = GetComponentInChildren<Animator>();
        facingDirection = inspectorFacingDir.position;
        transform.rotation = Quaternion.LookRotation(facingDirection);
    }

    void FixedUpdate()
    {
        if (moving)
        {
            if(sliding) { transform.position = Vector3.MoveTowards(transform.position, target, MOV_SPEED*2); }
            else transform.position = Vector3.MoveTowards(transform.position, target, MOV_SPEED);

            if ((transform.position - target).magnitude <= 0.01)
            {
                moving = false;
                sliding = false;
                animator.SetTrigger("Idle");

                if (currentPos.isExit)
                {
                    GameManager.instance.EndLevel();
                }

                else if (currentPos.containsButton)
                {
                    AudioManager.instance.Play("boton");
                    AudioManager.instance.Play("pinchos");
                    currentPos.OpenDoor();
                }
            }
        }
    }
    // Update is called once per frame
    private void Update()
    {
        if (GameManager.instance.OnMenu)
        {
            return;
        }

        if (Input.GetMouseButtonUp(0) && currentTurn == GameManager.instance.currentTurn && !_placingWool && !moveDone && !checkingRange && !_placingLaser && !_usingFlashlight)
        {
            GetSquareClicked();
            MoveablePositions();
        }
        else if (Input.GetMouseButtonUp(0) && currentTurn == GameManager.instance.currentTurn && _placingWool && hasWoolBall)
        {
            PlaceWoolBall();
        }
        else if (Input.GetMouseButtonUp(0) && currentTurn == GameManager.instance.currentTurn && _placingLaser && hasLaser)
        {
            PlaceLaser();
        }
        else if (Input.GetMouseButtonUp(0) && currentTurn == GameManager.instance.currentTurn && _usingFlashlight && hasFlashlight)
        {
            UseFlashlight();
        }

        if((Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.UpArrow)) && currentTurn == GameManager.instance.currentTurn && !_placingWool && !moveDone && !checkingRange && !_placingLaser && !_usingFlashlight)
        {
            CheckMove("north");
        }
        else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && currentTurn == GameManager.instance.currentTurn && !_placingWool && !moveDone && !checkingRange && !_placingLaser && !_usingFlashlight)
        {
            CheckMove("south");
        }
        else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && currentTurn == GameManager.instance.currentTurn && !_placingWool && !moveDone && !checkingRange && !_placingLaser && !_usingFlashlight)
        {
            CheckMove("east");
        }
        else if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && currentTurn == GameManager.instance.currentTurn && !_placingWool && !moveDone && !checkingRange && !_placingLaser && !_usingFlashlight)
        {
            CheckMove("west");
        }

        if(Input.GetKeyDown(KeyCode.Space) && currentTurn == GameManager.instance.currentTurn && !checkingRange && !GameManager.instance.waitingForAttack)
        {
            if (GameManager.instance.pleaseDont) GameManager.instance.pleaseDont = false;
            else
            {
                GameManager.instance.EndPlayerTurn();
                currentTurn++;
            }
        }

        else if (Input.GetKeyDown(KeyCode.U) && currentTurn == GameManager.instance.currentTurn && !checkingRange && !GameManager.instance.waitingForAttack)
        {
            if (GameManager.instance.pleaseDont) GameManager.instance.pleaseDont = false;
            else
            {
                UndoMovement();
            }
        }

        #region oldShortcuts
        //if(Input.GetKeyUp(KeyCode.DownArrow) && currentTurn == GameManager.instance.currentTurn && hasFlashlight && _usingFlashlight ) 
        //{
        //    UseFlashlight(new Vector3(0,0,-1));
        //}
        //if (Input.GetKeyUp(KeyCode.UpArrow) && currentTurn == GameManager.instance.currentTurn && hasFlashlight && _usingFlashlight)
        //{
        //    UseFlashlight(new Vector3(0, 0, 1));
        //}
        //if (Input.GetKeyUp(KeyCode.LeftArrow) && currentTurn == GameManager.instance.currentTurn && hasFlashlight && _usingFlashlight)
        //{
        //    UseFlashlight(new Vector3(-1, 0, 0));
        //}
        //if (Input.GetKeyUp(KeyCode.RightArrow) && currentTurn == GameManager.instance.currentTurn && hasFlashlight && _usingFlashlight)
        //{
        //    UseFlashlight(new Vector3(1, 0, 0));
        //}

        //if (Input.GetKeyDown(KeyCode.Y)) { GameManager.instance.EndPlayerTurn(); currentTurn++; } //For debugging purposes, temporal

        //if (Input.GetKeyDown(KeyCode.X)) { KnockOutEnemies(); } //For debugging purposes, temporal

        //if (Input.GetKeyDown(KeyCode.S)) { Squawk(); } //For debugging purposes, temporal

        //if (Input.GetKeyDown(KeyCode.D)) { Drink(); }//For debugging purposes, temporal

        //if (Input.GetKeyDown(KeyCode.W)) { _placingWool = !_placingWool; }//For debugging purposes, temporal

        //if (Input.GetKeyDown(KeyCode.L)) { _placingLaser = !_placingLaser; }//For debugging purposes, temporal

        //if (Input.GetKeyDown(KeyCode.F)) { _usingFlashlight = !_usingFlashlight; }//For debugging purposes, temporal
        #endregion
    }

    public void KnockOutEnemies()
    {
        Debug.Log("pum te pego");
        foreach (Enemy enemy in GameManager.instance.listOfEnemies)
        {
            if (!enemy.GetBlinded() && !enemy.GetDistracted() && !enemy.knockOut)
            {
                enemy.CheckVision();
            }
        }
        if (GameManager.instance.CloseEnemies(_isSeen, out Enemy knockedEnemy))
        {
            float oldFacingDirectionY = facingDirection.y;
            facingDirection = knockedEnemy.transform.position - transform.position;
            facingDirection.y = oldFacingDirectionY;
            RotateCharacter();
            actionDone = true;
            UpdateMoveable();
            animator.SetTrigger("Attack");
        }
    }

    public void SkipTurn()
    {
        GameManager.instance.EndPlayerTurn();
        currentTurn++;

    }

    private void MoveCharacter(Square squareTarget)
    {

        if (squareTarget.isHidingSpot)
        {
            GameManager.instance.CheckEnemiesVision();
            AudioManager.instance.Play("closeBox");
        }
        if (squareTarget.isOilPuddle) { Slip(squareTarget); animator.SetTrigger("Idle"); facingDirection = target - transform.position; RotateCharacter(); UpdateMoveable(); }
        else
        {
            animator.SetTrigger("Step");
            target = new Vector3(squareTarget.transform.position.x, transform.position.y, squareTarget.transform.position.z);
            moving = true;
            currentPos.isWalkable = true;
            currentPos.occupiedByPlayer = false;
            if (currentPos.isHidingSpot) IsHiding = false;
            lastPos = currentPos;
            currentPos = squareTarget;
            squareTarget.isWalkable = false;
            squareTarget.occupiedByPlayer = true;
            moveDone = true;
            facingDirection = target - transform.position;
            RotateCharacter();
            UpdateMoveable();

        }

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

        if (currentPos.isHidingSpot)
        {

            IsHiding = true;

        }
        else if (currentPos.containsWool)
        {
            if (!currentPos.wool.isLaser)
            {
                if (!hasWoolBall && currentPos.wool.isActiveAndEnabled)
                {
                    hasWoolBall = true;
                    currentPos.containsWool = false;
                    _woolball = currentPos.wool;
                    currentPos.wool = null;
                    _woolball.gameObject.SetActive(false);
                    _woolball.ForgetWoolball();
                }
            }
            else
            {
                if (!hasLaser && currentPos.wool.isActiveAndEnabled)
                {
                    hasLaser = true;
                    currentPos.containsWool = false;
                    _laser = currentPos.wool;
                    currentPos.wool = null;
                    _laser.gameObject.SetActive(false);
                    _laser.ForgetWoolball();
                }
            }

        }
        
        else if (currentPos.containsFlashlight)
        {
            currentPos.containsFlashlight = false;
            currentPos.DisableFlashlight();
            hasFlashlight = true;
        }

        GameManager.instance.UpdateBackpack();
    }

    private void GetSquareClicked()
    {
        Vector3 mousePosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        RaycastHit hit;

        if (currentPos.isHidingSpot) AudioManager.instance.Play("openBox");

        if (Physics.Raycast(ray, out hit))
        {
            if (walkablePositions.Contains(hit.transform.GetComponent<Square>()))
            {
                Square targetSquare = hit.transform.GetComponent<Square>();
                MoveCharacter(targetSquare);
            }
        }
    }

    private void CheckMove(string direction)
    {
        Vector3 possibleSquare = new();
        switch (direction)
        {
            case "north":
                possibleSquare = new Vector3(transform.position.x, 0, transform.position.z + 1);
                break;

            case "south":
                possibleSquare = new Vector3(transform.position.x, 0, transform.position.z - 1);
                break;

            case "east":
                possibleSquare = new Vector3(transform.position.x + 1, 0, transform.position.z);
                break;

            case "west":
                possibleSquare = new Vector3(transform.position.x - 1, 0, transform.position.z);
                break;

        }
        foreach(Square square in walkablePositions)
        {
            if(square.transform.position == possibleSquare)
            {
                MoveCharacter(square);
                break;
            }
        }
    }

    private void Slip(Square targetSquare)
    {
        Vector3 direction = targetSquare.transform.position - currentPos.transform.position;
        target = new Vector3(targetSquare.transform.position.x, transform.position.y, targetSquare.transform.position.z);
        moving = true;
        sliding = true;
        currentPos.isWalkable = true;
        currentPos.occupiedByPlayer = false;
        if (currentPos.isHidingSpot) IsHiding = false;
        lastPos = currentPos;
        currentPos = targetSquare;
        targetSquare.isWalkable = false;
        targetSquare.occupiedByPlayer = true;
        moveDone = true;
        if (currentPos.isOilPuddle)
        {
            List<Square> adjacents = GridManager.instance.GetAdjacents(currentPos);
            foreach (Square adjacent in adjacents)
            {
                if (adjacent.transform.position == currentPos.transform.position + direction)
                {
                    Slip(adjacent);
                }
            }
        }

    }

    private void PlaceWoolBall()
    {
        Vector3 mousePosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (walkablePositions.Contains(hit.transform.GetComponent<Square>()))
            {
                Square target = hit.transform.GetComponent<Square>();
                if (!target.containsWool)
                {
                    target.containsWool = true;
                    target.wool = _woolball;
                    hasWoolBall = false;
                    _woolball.transform.position = new Vector3(hit.transform.position.x, _woolball.transform.position.y, hit.transform.position.z);
                    _woolball.tile = target;
                    _woolball.gameObject.SetActive(true);
                    _placingWool = false;
                    GameManager.instance.PlayerPlaceWoolball();
                }
            }
        }
    }

    private void PlaceLaser()
    {
        Vector3 mousePosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        List<Square> placeablePositions = new();
        placeablePositions = GridManager.instance.GetMultipleAdjacents(currentPos, 3);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (placeablePositions.Contains(hit.transform.GetComponent<Square>()))
            {
                Square target = hit.transform.GetComponent<Square>();
                if (!target.containsWool)
                {
                    target.containsWool = true;
                    target.wool = _laser;
                    hasLaser = false;
                    _laser.transform.position = new Vector3(hit.transform.position.x, _laser.transform.position.y, hit.transform.position.z);
                    _laser.tile = target;
                    _laser.gameObject.SetActive(true);
                    _placingWool = false;
                    GameManager.instance.PlayerPlaceLaser();
                }
            }
        }
    }

    private Vector3 GetPlacingDirection()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 direction = new();

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        RaycastHit hit;
        List<Square> posibles = GridManager.instance.GetMultipleAdjacentsStopAtWalls(currentPos, 15);

        if (Physics.Raycast(ray, out hit))
        {
            if (posibles.Contains(hit.transform.GetComponent<Square>()))
            {
                Square target = hit.transform.GetComponent<Square>();
                Vector3 aux = target.transform.position - this.transform.position;
                direction = new Vector3(aux.x, 0, aux.z);
                direction = direction.normalized;
            }
        }
        return direction;
    }

    private void UseFlashlight()
    {
        Vector3 direction = GetPlacingDirection();
        if (direction != new Vector3(0, 0, 0))
        {
            hasFlashlight = false;

            RaycastHit hit;
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            if (Physics.Raycast(pos, direction, out hit))
            {
                Debug.DrawRay(pos, direction, Color.green, 50f);
                if (hit.collider.CompareTag("Enemy"))
                {
                    hit.collider.GetComponent<Enemy>().GetBlinded(direction);
                }
            }
            GameManager.instance.CancelAction();
        }
    }

    public void UpdateMoveable()
    {
        MoveablePositions();
    }

    public void Seen(bool seen)
    {
        IsSeen = seen;
    }

    public void NewTurn()
    {
    }

    public void Squawk()
    {
        if (canSquawk)
        {
            if (!GameManager.instance.cancelButton.gameObject.activeSelf)
            {
                GameManager.instance.SetUpSquawk();
                checkingRange = true;
            }
            else
            {
                animator.SetTrigger("Squawk");
                GameManager.instance.PlayerSquawk();
                canSquawk = false;
            }

        }
        else
        {
            //Debug.Log("Tienes la garganta seca");
        }
    }

    public void Drink()
    {
        if (fountainClose && !canSquawk)
        {
            if (fountain.DecreaseFountainCounter())
            {
                float oldFacingDirectionY = facingDirection.y;
                facingDirection = fountain.transform.position - transform.position;
                facingDirection.y = oldFacingDirectionY;
                RotateCharacter();
                canSquawk = true;
                GameManager.instance.UpdateBackpack();
            }
            else
            {
                //Debug.Log("Fuente Seca");
            }
        }
        else
        {
            //Debug.Log("No hay agua cerca");
        }
    }

    public void EnablePlacingWoolBall()
    {
        _placingWool = true;
        GameManager.instance.SetUpWoolBall();
    }

    public void DisablePlacingWoolBall()
    {
        _placingWool = false;
    }

    public void EnablePlacingLaser()
    {
        _placingLaser = true;
        GameManager.instance.SetUpLaser();
    }

    public void DisablePlacingLaser()
    {
        _placingLaser = false;
    }

    public void EnablePlacingFlaslight()
    {
        _usingFlashlight = true;
        GameManager.instance.SetUpTorch();
    }

    public void DisablePlacingFlashlight()
    {
        _usingFlashlight = false;
    }

    public void AddObserver(IObserver<bool> observer)
    {
        _boolObservers.Add(observer);
    }

    public void RemoveObserver(IObserver<bool> observer)
    {
        _boolObservers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _boolObservers)
        {
            observer?.UpdateObserver(IsHiding);
        }
    }

    private void RotateCharacter()
    {

        transform.rotation = Quaternion.LookRotation(facingDirection);

    }
    public void Die()
    {
        animator.SetTrigger("Die");
    }

    private void UndoMovement()
    {
        Debug.Log("NOT IMPLEMENTED");
        //if (lastPos == null) return;

        //Debug.Log("undo");
        //transform.position = new Vector3(lastPos.transform.position.x, transform.position.y, lastPos.transform.position.z);
        //lastPos.isWalkable = false;
        //currentPos.isWalkable = true;
        //currentPos = lastPos;
        //lastPos = null;
        //moveDone = false;
        //UpdateMoveable();
    }
}
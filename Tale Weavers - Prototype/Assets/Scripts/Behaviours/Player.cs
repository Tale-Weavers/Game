using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MoveableCharacter
{
    [SerializeField] private bool _isSeen;
    [SerializeField] public bool _isHiding;

    private Square fountain;

    public bool checkingRange;

    public bool actionDone = false;

    public bool canSquawk = false;
    public bool fountainClose = false;
    public bool hasWoolBall = false;
    public bool hasLaser = false;

    private WoolBall _woolball;
    private WoolBall _laser;

    [SerializeField] private bool _placingWool;
    [SerializeField] private bool _placingLaser;

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

        if (Input.GetMouseButtonUp(0) && currentTurn == GameManager.instance.currentTurn && !_placingWool && !moveDone && !checkingRange && !_placingLaser)
        {
            MoveCharacter();
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

        if (Input.GetKeyDown(KeyCode.Y)) { GameManager.instance.EndPlayerTurn(); currentTurn++; } //For debugging purposes, temporal

        if (Input.GetKeyDown(KeyCode.X) && !_isSeen) { KnockOutEnemies(); } //For debugging purposes, temporal

        if (Input.GetKeyDown(KeyCode.S)) { Squawk(); } //For debugging purposes, temporal

        if (Input.GetKeyDown(KeyCode.D)) { Drink(); }//For debugging purposes, temporal

        if (Input.GetKeyDown(KeyCode.W)) { _placingWool = !_placingWool; }//For debugging purposes, temporal

        if (Input.GetKeyDown(KeyCode.L)) { _placingLaser = !_placingLaser; }//For debugging purposes, temporal
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
                        }
                    }

                }
                else if(currentPos.containsButton)
                {
                    currentPos.OpenDoor();
                }
                //GameManager.instance.EndPlayerTurn();
                //currentTurn++;
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
            if (!GameManager.instance.cancelButton.gameObject.activeSelf)
            {
                GameManager.instance.SetUpSquawk();
                checkingRange = true;
            }
            else
            {
                GameManager.instance.PlayerSquawk();
                canSquawk = false;
                checkingRange = true;
            }

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

}
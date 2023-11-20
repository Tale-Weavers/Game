using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour,ISubject<bool>
{
    public static GameManager instance;
    public int currentTurn;
    public Enemy[] listOfEnemies;
    public Player player;
    public bool paused;
    public bool inDialogue;

    public CanvasController canvasC;

    public string nextLevelName;

    private List<IObserver<bool>> _observers = new List<IObserver<bool>>();

    public bool onMenu;

    [HideInInspector] public Button attackButton;
    [HideInInspector] public Button skipButton;
    [HideInInspector] public Button squawkButton;
    [HideInInspector] public Button squawkConfirmButton;
    [HideInInspector] public Button drinkButton;
    [HideInInspector] public Button woolBallButton;
    [HideInInspector] public Button laserButton;
    [HideInInspector] public Button torchButton;
    [HideInInspector] public Button mainMenu;
    [HideInInspector] public Button cancelButton;

    [SerializeField] private float _squawkRange;
    [SerializeField] private List<WoolBall> _woolBall = new();
    [HideInInspector] public bool enemyTurn;


    [SerializeField] private CheckLevelCompletion _checkLevelCompletion;

    public int enemiesKnockedOut;
    public int enemiesDistracted;

    public bool woolBallUsed;
    public bool laserUsed;
    public bool squawkUsed;
    public bool flashlightUsed;


    private void Awake()
    {
        Time.timeScale = 1.0f;
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        _checkLevelCompletion = GetComponent<CheckLevelCompletion>();
    }

    public void StartCharacters()
    {

        foreach (Enemy enemy in listOfEnemies)
        {
            enemy.gameObject.SetActive(true);
        }
        canvasC.Initiate();
        player.gameObject.SetActive(true);
        attackButton.gameObject.SetActive(true);
        skipButton.gameObject.SetActive(true);
       
        AudioManager.instance.InilitializeVolumen();
        SetUpMusic();
        AudioManager.instance.Play("musicaNivel");
    }

    public void SetUpMusic()
    {
        AudioManager.instance.Stop("musicaVictoria");
        AudioManager.instance.Stop("musicaDerrota");
        AudioManager.instance.Stop("musicaMenu");
        AudioManager.instance.Stop("musicaAtrapado");
    }

    public void NextTurn()
    {
        skipButton.gameObject.SetActive(true);
        enemyTurn = false;
        //StartCoroutine(TimeWaste(0));

        StartCoroutine(TimeWaste(1));

        player.UpdateMoveable();
        if (player.canSquawk) squawkButton.gameObject.SetActive(true);
        if (player.fountainClose) drinkButton.gameObject.SetActive(true);
        if (player.hasWoolBall) woolBallButton.gameObject.SetActive(true);
        if (player.hasLaser) laserButton?.gameObject.SetActive(true);
        if (player.hasFlashlight) torchButton?.gameObject.SetActive(true);
        attackButton.gameObject.SetActive(true);
        skipButton.gameObject.SetActive(true);
        currentTurn++;
        canvasC.AddTurn(currentTurn);
        foreach (WoolBall woolBall in _woolBall)
        {
            woolBall.GetComponent<Collider>().enabled = false;
        }
    }

    public void EndPlayerTurn()
    {
        enemyTurn = true;
        attackButton.gameObject.SetActive(false);
        skipButton.gameObject.SetActive(false);
        squawkButton.gameObject.SetActive(false);
        drinkButton.gameObject.SetActive(false);
        woolBallButton.gameObject.SetActive(false);
        laserButton?.gameObject.SetActive(false);
        torchButton?.gameObject.SetActive(false);

        player.moveDone = false;
        player.actionDone = false;
        foreach (WoolBall woolBall in _woolBall)
        {
            woolBall.GetComponent<Collider>().enabled = true;
        }
        NotifyObservers(true);
        StartCoroutine(EnemyMovement());
    }

    private IEnumerator TimeWaste(int time)
    {
        yield return new WaitForSeconds(time);
    }

    private IEnumerator EnemyMovement()
    {
        foreach (Enemy enemy in listOfEnemies)
        {
            if (!enemy.knockOut)
            {
                enemy.moveDone = false;

                enemy.StartAction();

                enemy.UpdateVisionCone();

                
            }
        }
        
        yield return new WaitForSeconds(1);
        NextTurn();
    }

    public void NotifyEnemies(bool seen)
    {
        foreach (Enemy enemy in listOfEnemies)
        {
            enemy.PlayerSeen(seen);
        }
    }

    public void CheckEnemiesVision()
    {
        bool hidingSuccesful = true;
        foreach (Enemy enemy in listOfEnemies)
        {
            hidingSuccesful = enemy.PlayerHidCheck();
        }
        if (hidingSuccesful)
        {
            player.Seen(false);
            NotifyEnemies(false);
        }
    }

    public void RestartLevel()
    {
        StartCoroutine(SetupLevel());
        Time.timeScale = 0.0f;
    }

    public void NextLevel()
    {
        LevelManager.instance.LoadScene(nextLevelName);
    }

    private IEnumerator SetupLevel()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        string name = SceneManager.GetActiveScene().name;
        LevelManager.instance.LoadScene(name);
        Time.timeScale = 1.0f;
    }

    public bool CloseEnemies(bool isSeen, out Enemy knockedEnemy)
    {
        knockedEnemy = null;
        bool enemyHit = false;
        

        if (!isSeen)
        {
            foreach (Enemy enemy in listOfEnemies)
            {
                Vector3 distance = enemy.transform.position - player.transform.position;
                if (distance.magnitude < 1.3f && !enemy.knockOut)
                {
                    StartCoroutine(WaitForKnockOut(enemy));
                    enemyHit = true;
                    knockedEnemy = enemy;
                    attackButton.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            foreach (Enemy enemy in listOfEnemies)
            {
                Vector3 distance = enemy.transform.position - player.transform.position;
                if (distance.magnitude < 1.3f && !enemy.knockOut && (enemy.GetDistracted() || enemy.GetBlinded()))
                {
                    StartCoroutine(WaitForKnockOut(enemy));
                    enemyHit = true;
                    knockedEnemy = enemy;
                    attackButton.gameObject.SetActive(false);
                }
            }
        }

        if (!enemyHit) { Debug.Log("NO HAY ENEMIGOS CERCA"); }
        return enemyHit;
    }

    public void EndLevel()
    {
        canvasC.EndLevel();
        //Debug.Log($"Numero de estrellas conseguido: {_checkLevelCompletion.CountStars()}");
        AudioManager.instance.Stop("musicaAtrapado");
        AudioManager.instance.Stop("musicaNivel");
        AudioManager.instance.Play("musicaVictoria");
    }

    public void EndLevelLost()
    {

        StartCoroutine(EndLevelCoroutine());
        
    }

    public void PlayerSquawk()
    {
        squawkButton.gameObject.SetActive(false);
        foreach (Enemy enemy in listOfEnemies)
        {
            Vector3 distance = (enemy.transform.position - player.transform.position);
            if (distance.magnitude < _squawkRange)
            {
                Debug.Log(enemy.name);
                enemy.AlertEnemy(player.currentPos);
                squawkUsed = true;
                
            }
            player.canSquawk = false;
        }
        CancelAction();
        AudioManager.instance.Play("squawk");
    }

    public void EnemyFinishedExploring()
    {
        foreach (Enemy enemy in listOfEnemies)
        {
            enemy.EndExploring();
        }
    }

    public void PlayerPlaceWoolball()
    {
        woolBallButton.gameObject.SetActive(false);
        CancelAction();
        woolBallUsed = true;
    }

    public void PlayerPlaceLaser()
    {
        laserButton?.gameObject.SetActive(false);
        CancelAction();
        laserUsed = true;
    }

    public void PlayerPlaceTorch()
    {
        torchButton?.gameObject.SetActive(false);
        CancelAction();
        flashlightUsed = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SetUpSquawk()
    {
        GridManager.instance.DrawRange(0, player.currentPos);

        attackButton.gameObject.SetActive(false);
        skipButton.gameObject.SetActive(false);
        drinkButton.gameObject.SetActive(false);
        woolBallButton.gameObject.SetActive(false);
        laserButton?.gameObject.SetActive(false);
        squawkButton.gameObject.SetActive(false);
        squawkConfirmButton.gameObject.SetActive(true);
        torchButton?.gameObject.SetActive(false);

        cancelButton.gameObject.SetActive(true);
    }

    public void SetUpWoolBall()
    {
        GridManager.instance.DrawRange(1, player.currentPos);

        attackButton.gameObject.SetActive(false);
        skipButton.gameObject.SetActive(false);
        drinkButton.gameObject.SetActive(false);
        squawkButton.gameObject.SetActive(false);
        laserButton?.gameObject.SetActive(false);
        torchButton?.gameObject.SetActive(false);

        cancelButton.gameObject.SetActive(true);
    }

    public void SetUpLaser()
    {
        GridManager.instance.DrawRange(2, player.currentPos);

        attackButton.gameObject.SetActive(false);
        skipButton.gameObject.SetActive(false);
        drinkButton.gameObject.SetActive(false);
        squawkButton.gameObject.SetActive(false);
        woolBallButton.gameObject.SetActive(false);
        torchButton?.gameObject.SetActive(false);

        cancelButton.gameObject.SetActive(true);
    }

    public void SetUpTorch()
    {
        GridManager.instance.DrawRange(3, player.currentPos);

        attackButton.gameObject.SetActive(false);
        skipButton.gameObject.SetActive(false);
        drinkButton.gameObject.SetActive(false);
        squawkButton.gameObject.SetActive(false);
        woolBallButton.gameObject.SetActive(false);
        laserButton?.gameObject.SetActive(false);

        cancelButton.gameObject.SetActive(true);
    }

    public void CancelAction()
    {
        GridManager.instance.CleanRange();

        attackButton.gameObject.SetActive(true);
        skipButton.gameObject.SetActive(true);
        player.DisablePlacingWoolBall();
        player.DisablePlacingLaser();
        player.DisablePlacingFlashlight();
        squawkConfirmButton.gameObject.SetActive(false);
        if (player.fountainClose)
        {
            drinkButton.gameObject.SetActive(true);
        }
        if (player.hasWoolBall)
        {
            woolBallButton.gameObject.SetActive(true);
        }
        if (player.hasLaser)
        {
            laserButton?.gameObject.SetActive(true);
        }
        if (player.hasFlashlight)
        {
            torchButton?.gameObject.SetActive(true);
        }
        else
        {
            torchButton?.gameObject.SetActive(false);
        }
        if (player.canSquawk)
        {
            squawkButton.gameObject.SetActive(true);
        }
        cancelButton.gameObject.SetActive(false);
        player.checkingRange = false;
        NotifyObservers(false);
    }

    public void SetUpButtons(Button[] botones)
    {
        attackButton = botones[0];

        skipButton = botones[1];
        squawkButton = botones[2];
        drinkButton = botones[3];
        woolBallButton = botones[4];
        laserButton = botones[5];
        torchButton = botones[6];
        mainMenu = botones[7];
        cancelButton = botones[8];
        squawkConfirmButton = botones[9];
    }

    public void AddObserver(IObserver<bool> observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver<bool> observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers(bool data)
    {
        foreach (IObserver<bool> observer in _observers)
        {
            observer?.UpdateObserver(data);
        }
    }

    public void NotifyObservers()
    {
        throw new System.NotImplementedException();
    }

    private IEnumerator EndLevelCoroutine()
    {
        player.Die();
        yield return new WaitForSeconds(2);
        canvasC.LostLevel();
        AudioManager.instance.Stop("musicaAtrapado");
        AudioManager.instance.Play("musicaDerrota");
    }
    private IEnumerator WaitForKnockOut(Enemy enemy)
    {
        yield return new WaitForSeconds(1);
        enemy.KnockEnemy();
    }
}
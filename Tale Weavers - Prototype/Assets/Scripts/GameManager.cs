using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int currentTurn;
    public Enemy[] listOfEnemies;
    public Player player;

    public TextMeshProUGUI turnText;
    public TextMeshProUGUI winText;

    [Header("Buttons")]
    public Button attackButton;

    public Button skipButton;
    public Button squawkButton;
    public Button drinkButton;
    public Button woolBallButton;
    public Button laserButton;
    public Button mainMenu;
    public Button cancelButton;

    [SerializeField] private float _squawkRange;
    [SerializeField] private List<WoolBall> _woolBall = new();

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
    }

    public void StartCharacters()
    {
        foreach (Enemy enemy in listOfEnemies)
        {
            enemy.gameObject.SetActive(true);
        }
        player.gameObject.SetActive(true);
        attackButton.gameObject.SetActive(true);
        skipButton.gameObject.SetActive(true);
        AudioManager.instance.Play("cancion");
    }

    public void NextTurn()
    {
        //StartCoroutine(TimeWaste(0));
        player.UpdateMoveable();
        if (player.canSquawk) squawkButton.gameObject.SetActive(true);
        if (player.fountainClose) drinkButton.gameObject.SetActive(true);
        if (player.hasWoolBall) woolBallButton.gameObject.SetActive(true);
        if (player.hasLaser) laserButton?.gameObject.SetActive(true);
        attackButton.gameObject.SetActive(true);
        skipButton.gameObject.SetActive(true);
        currentTurn++;
        turnText.text = $"Current turn: {currentTurn}";
        foreach(WoolBall woolBall in _woolBall)
        {
            woolBall.GetComponent<Collider>().enabled = false;
        }
    }

    public void EndPlayerTurn()
    {
        attackButton.gameObject.SetActive(false);
        skipButton.gameObject.SetActive(false);
        squawkButton.gameObject.SetActive(false);
        drinkButton.gameObject.SetActive(false);
        woolBallButton.gameObject.SetActive(false);
        laserButton?.gameObject.SetActive(false);
        player.moveDone = false;
        player.actionDone = false;
        foreach (WoolBall woolBall in _woolBall)
        {
            woolBall.GetComponent<Collider>().enabled = true;
        }
        StartCoroutine(EnemyMovement());
    }

    //private IEnumerator TimeWaste(int time)
    //{
    //    yield return new WaitForSeconds(time);
    //}

    private IEnumerator EnemyMovement()
    {
        foreach (Enemy enemy in listOfEnemies)
        {
            if (!enemy.knockOut)
            {
                enemy.moveDone = false;
                enemy.StartAction();
            }
        }
        NextTurn();
        yield return null;
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

    private IEnumerator SetupLevel()
    {
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }

    public bool CloseEnemies()
    {
        bool enemyHit = false;
        foreach (Enemy enemy in listOfEnemies)
        {
            Vector3 distance = enemy.transform.position - player.transform.position;
            if (distance.magnitude < 1.1f && !enemy.knockOut)
            {
                enemy.KnockEnemy();
                enemyHit = true;
                attackButton.gameObject.SetActive(false);
            }
        }
        if (!enemyHit) { Debug.Log("NO HAY ENEMIGOS CERCA"); }
        return enemyHit;
    }

    public void EndLevel()
    {
        winText.text = "Level Completed";
        winText.gameObject.SetActive(true);
        RestartLevel();
    }

    public void EndLevelLost()
    {
        winText.text = "GAME OVER";
        winText.gameObject.SetActive(true);

        RestartLevel();
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
            }
        }
        CancelAction();
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
    }

    public void PlayerPlaceLaser()
    {
        laserButton?.gameObject.SetActive(false);
        CancelAction();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void SetUpSquawk()
    {
        GridManager.instance.DrawRange(0, player.currentPos);

        attackButton.gameObject.SetActive(false);
        skipButton.gameObject.SetActive(false);
        drinkButton.gameObject.SetActive(false);
        woolBallButton.gameObject.SetActive(false);
        laserButton?.gameObject.SetActive(false);

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

        cancelButton.gameObject.SetActive(true);
    }

    public void SetUpLaser()
    {
        GridManager.instance.DrawRange(2, player.currentPos);

        attackButton.gameObject.SetActive(false);
        skipButton.gameObject.SetActive(false);
        drinkButton.gameObject.SetActive(false);
        squawkButton.gameObject.SetActive(false);
        woolBallButton.gameObject.SetActive(false) ;
        cancelButton.gameObject.SetActive(true);
    }

    public void CancelAction()
    {
        GridManager.instance.CleanRange();

        attackButton.gameObject.SetActive(true);
        skipButton.gameObject.SetActive(true);
        player.DisablePlacingWoolBall();
        player.DisablePlacingLaser();
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
        cancelButton.gameObject.SetActive(false);
        player.checkingRange = false;
    }
}
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int currentTurn;
    public Enemy[] listOfEnemies;
    public Player player;

    public TextMeshProUGUI turnText;

    public Button attackButton;

    public Button skipButton;

    private void Awake()
    {
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
    }

    public void NextTurn()
    {
        //StartCoroutine(TimeWaste(0));
        player.UpdateMoveable();
        attackButton.gameObject.SetActive(true);
        skipButton.gameObject.SetActive(true);
        currentTurn++;
        turnText.text = $"Current turn: {currentTurn}";
    }

    public void EndPlayerTurn()
    {
        attackButton.gameObject.SetActive(false);
        skipButton.gameObject.SetActive(false);
        player.moveDone = false;
        player.actionDone = false;
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
                yield return new WaitForSeconds(0.5f);
                enemy.StartAction();
            }

        }
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
        foreach(Enemy enemy in listOfEnemies) 
        { 
            hidingSuccesful = enemy.PlayerHidCheck(); 
        }
        if (hidingSuccesful)
        {
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
        yield return new WaitForSecondsRealtime(5);
        SceneManager.LoadScene(0);
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
        Debug.Log("VICTORIA ROYALE");
        RestartLevel();
    }
}
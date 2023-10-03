using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int currentTurn;
    public Enemy[] listOfEnemies;
    public Player player;

    public TextMeshProUGUI turnText;


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
    }

    public void NextTurn()
    {
        //StartCoroutine(TimeWaste(0));
        player.UpdateMoveable();
        currentTurn++;
        turnText.text = $"Current turn: {currentTurn}";
    }

    public void EndPlayerTurn()
    {
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
            
            yield return new WaitForSeconds(0.5f);
            enemy.StartAction();

        }
        NextTurn();
    }
}

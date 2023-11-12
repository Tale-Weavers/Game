using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{

    public Button skipButton;
    public Button attackButton;
    public Button squawkButton;
    public Button drinkButton;
    public Button woolBallButton;
    public Button laserButton;
    public Button torchButton;
    public Button mainMenuButton;
    public Button cancelButton;

    public Button restartButton;
    public Button optionsButton;
    public Button skipLevelButton;

    public TextMeshProUGUI turnText;
    public TextMeshProUGUI winText;

    private Button[] buttons = new Button[9];

    public void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Initiate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Initiate()
    {
        buttons[0] = attackButton;
        buttons[1] = skipButton;
        buttons[2] = squawkButton;
        buttons[3] = drinkButton;
        buttons[4] = woolBallButton;
        buttons[5] = laserButton;
        buttons[6] = torchButton;
        buttons[7] = mainMenuButton;
        buttons[8] = cancelButton;


        skipButton.onClick.AddListener(GameManager.instance.player.SkipTurn);
        squawkButton.onClick.AddListener(GameManager.instance.player.Squawk);
        drinkButton.onClick.AddListener(GameManager.instance.player.Drink);
        woolBallButton.onClick.AddListener(GameManager.instance.player.EnablePlacingWoolBall);
        torchButton.onClick.AddListener(GameManager.instance.player.EnablePlacingFlaslight);
        laserButton.onClick.AddListener(GameManager.instance.player.EnablePlacingLaser);
        cancelButton.onClick.AddListener(GameManager.instance.CancelAction);
        attackButton.onClick.AddListener(GameManager.instance.player.KnockOutEnemies);
        mainMenuButton.onClick.AddListener(GameManager.instance.MainMenu);

        skipLevelButton.onClick.AddListener(GameManager.instance.NextLevel);

        restartButton.onClick.AddListener(GameManager.instance.RestartLevel);

        //optionsButton.onClick.AddListener(GameManager.instance.Optiones);

        GameManager.instance.SetUpButtons(buttons);
    }

    public void AddTurn(int currentTurn)
    {
        turnText.text = $"Current turn: {currentTurn}";
    }

    public void EndLevel()
    {
        winText.text = "Level Completed";
        winText.gameObject.SetActive(true);
    }

    public void LostLevel()
    {
        winText.text = "GAME OVER";
        winText.gameObject.SetActive(true);
    }



}

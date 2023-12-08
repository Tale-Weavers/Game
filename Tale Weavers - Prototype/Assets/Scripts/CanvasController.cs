using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CanvasController : MonoBehaviour,IObserver<bool>
{
    [Header ("UI in Game")]
    public Button skipButton;
    public Button attackButton;
    public Button squawkButton;
    public Button squawkConfirmButton;
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

    [SerializeField] private GameObject _gameplayScreenGO;

    [SerializeField]private ObjectMenu _menu;

    [Header("Win Screen")]
    public Button retryButtonWS;
    public Button homeButtonWS;
    public Button nextLevelButtonWS;
    [SerializeField] private GameObject _winScreenGO;

    [Header("Fail Screen")]
    public Button retryButtonFS;
    public Button homeButtonFS;
    [SerializeField] private GameObject _failScreenGO;

    [Header("Options Screen")]
    public Slider masterSlider;
    public Slider sfxSlider;
    public Slider musicSlider;
    public Button returnButton;
    [SerializeField] private GameObject _optionsScreenGO;

    [Header("Loading Screen")]
    public Image loadingProgressBar;
    public GameObject loadingScreenGO;

    [Header("Other")]
    public Button closeStarsInfoButton;
    public GameObject[] starsGO;
    public TMP_Text levelText;
    private bool lastOnMenu;

    private Button[] buttons = new Button[10];

    public void Awake()
    {
        masterSlider.onValueChanged.AddListener(AudioManager.instance.GeneralSound);
        sfxSlider.onValueChanged.AddListener(AudioManager.instance.SFXSound);
        musicSlider.onValueChanged.AddListener(AudioManager.instance.MusicSound);
        AudioManager.instance.sliderGeneral = masterSlider;
        AudioManager.instance.sliderSFX = sfxSlider;
        AudioManager.instance.sliderMusic = musicSlider;
        
    }

    public void Initiate()
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
        buttons[9] = squawkConfirmButton;


        skipButton.onClick.AddListener(GameManager.instance.player.SkipTurn);
        squawkButton.onClick.AddListener(GameManager.instance.player.Squawk);
        squawkConfirmButton.onClick.AddListener(GameManager.instance.player.Squawk);
        drinkButton.onClick.AddListener(GameManager.instance.player.Drink);
        woolBallButton.onClick.AddListener(GameManager.instance.player.EnablePlacingWoolBall);
        torchButton.onClick.AddListener(GameManager.instance.player.EnablePlacingFlaslight);
        laserButton.onClick.AddListener(GameManager.instance.player.EnablePlacingLaser);
        cancelButton.onClick.AddListener(GameManager.instance.CancelAction);
        attackButton.onClick.AddListener(GameManager.instance.player.KnockOutEnemies);
        mainMenuButton.onClick.AddListener(GameManager.instance.MainMenu);

        skipLevelButton.onClick.AddListener(GameManager.instance.NextLevel);

        restartButton.onClick.AddListener(GameManager.instance.RestartLevel);

        optionsButton.onClick.AddListener(OpenSettings);
        returnButton.onClick.AddListener(CloseSettings);


        retryButtonWS.onClick.AddListener(GameManager.instance.RestartLevel);
        nextLevelButtonWS.onClick.AddListener(GameManager.instance.NextLevel);
        homeButtonWS.onClick.AddListener(GameManager.instance.MainMenu);

        homeButtonFS.onClick.AddListener(GameManager.instance.MainMenu);
        retryButtonFS.onClick.AddListener(GameManager.instance.RestartLevel);

        closeStarsInfoButton?.onClick.AddListener(GameManager.instance.DeactivateOnMenu);

        masterSlider.onValueChanged.AddListener(AudioManager.instance.GeneralSound);
        sfxSlider.onValueChanged.AddListener(AudioManager.instance.SFXSound);
        musicSlider.onValueChanged.AddListener(AudioManager.instance.MusicSound);
        AudioManager.instance.sliderGeneral = masterSlider;
        AudioManager.instance.sliderSFX = sfxSlider;
        AudioManager.instance.sliderMusic = musicSlider;

        LevelManager.instance.AddReferneces(loadingScreenGO, loadingProgressBar);

        GameManager.instance.SetUpButtons(buttons);

        GameManager.instance.AddObserver(this);

        if (GameManager.instance.isTutorial)
        {
            levelText.text = SceneManager.GetActiveScene().name;
        }
        else
        {
            string levelNameAux = SceneManager.GetActiveScene().name;
            levelNameAux = levelNameAux[6..];
            string leveltextaux = "Level ";
            levelText.text = leveltextaux + levelNameAux;
        }

    }

    public void AddTurn(int currentTurn)
    {
        turnText.text = $"Current turn: {currentTurn}";
    }

    public void EndLevel()
    {
        _gameplayScreenGO.SetActive(false);
        _winScreenGO.SetActive(true);
        optionsButton.gameObject.SetActive(false);
    }

    public void LostLevel()
    {
        _gameplayScreenGO.SetActive(false);
        _failScreenGO.SetActive(true);
        optionsButton.gameObject.SetActive(false);
    }

    public void EndTurn()
    {
        _menu.EndTurn();
    }

    public void UpdateObserver(bool data)
    {
        if (data)
        {
            EndTurn();
        }
        else
        {
            _menu.UpdateMenu();
        }

    }

    public void UpdateMenu()
    {
        _menu.UpdateMenu();
    }

    public void OpenSettings()
    {
        _optionsScreenGO.SetActive(true);
        lastOnMenu = GameManager.instance.OnMenu;
        GameManager.instance.OnMenu = true;
        returnButton.Select();
    }

    public void CloseSettings()
    {
        _optionsScreenGO.SetActive(false);
        GameManager.instance.OnMenu = lastOnMenu;
    }

    public bool GetOpenSettings()
    {
        return _optionsScreenGO.activeSelf;
    }
}

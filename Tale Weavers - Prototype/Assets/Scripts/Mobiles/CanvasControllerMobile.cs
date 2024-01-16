using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasControllerMobile : MonoBehaviour
{

    [SerializeField] private GameObject _gameplayScreenGO;

    public Button restartButton;
    public Button optionsButton;
    public Button skipLevelButton;
    public Button helpButton;
    public Button mainMenuButton;
    public Timer timer;

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

    [Header("Help Screen")]
    public GameObject[] helpImages;
    public Button nextPageButton;
    public Button previousPageButton;
    public Button leaveHelpButton;
    [SerializeField] private int helpIndx;
    [SerializeField] private GameObject _helpScreenGO;

    [Header("Start Screen")]
    public Button startGameButton;
    [SerializeField] private GameObject _startScreenGO;

    public TMP_Text levelText;
    private bool lastOnMenu;

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
        restartButton.onClick.AddListener(GameManagerMobile.instance.RestartLevel);
        mainMenuButton.onClick.AddListener(GameManagerMobile.instance.MainMenu);

        optionsButton.onClick.AddListener(OpenSettings);
        returnButton.onClick.AddListener(CloseSettings);
        helpButton.onClick.AddListener(OpenHelpScreen);

        startGameButton.onClick.AddListener(GameManagerMobile.instance.StartGame);

        retryButtonWS.onClick.AddListener(GameManagerMobile.instance.RestartLevel);
        nextLevelButtonWS.onClick.AddListener(GameManagerMobile.instance.NextLevel);
        homeButtonWS.onClick.AddListener(GameManagerMobile.instance.MainMenu);

        homeButtonFS.onClick.AddListener(GameManagerMobile.instance.MainMenu);
        retryButtonFS.onClick.AddListener(GameManagerMobile.instance.RestartLevel);

        masterSlider.onValueChanged.AddListener(AudioManager.instance.GeneralSound);
        sfxSlider.onValueChanged.AddListener(AudioManager.instance.SFXSound);
        musicSlider.onValueChanged.AddListener(AudioManager.instance.MusicSound);

        GameManagerMobile.instance.timer = timer;

        nextPageButton.onClick.AddListener(NextPage);
        previousPageButton.onClick.AddListener(PreviousPage);
        leaveHelpButton.onClick.AddListener(CloseHelpScreen);

        AudioManager.instance.sliderGeneral = masterSlider;
        AudioManager.instance.sliderSFX = sfxSlider;
        AudioManager.instance.sliderMusic = musicSlider;

        LevelManager.instance.AddReferneces(loadingScreenGO, loadingProgressBar);

        string levelNameAux = SceneManager.GetActiveScene().name;
        levelNameAux = levelNameAux[6..];
        string leveltextaux = "Level ";
        levelText.text = leveltextaux + levelNameAux;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void OpenSettings()
    {
        _optionsScreenGO.SetActive(true);
        lastOnMenu = GameManagerMobile.instance.OnMenu;
        GameManagerMobile.instance.OnMenu = true;
        returnButton.Select();
    }

    public void CloseSettings()
    {
        _optionsScreenGO.SetActive(false);
        GameManagerMobile.instance.OnMenu = lastOnMenu;
    }

    public bool GetOpenSettings()
    {
        return _optionsScreenGO.activeSelf;
    }

    public void OpenHelpScreen()
    {
        _helpScreenGO.SetActive(true);
        lastOnMenu = GameManagerMobile.instance.OnMenu;
        GameManagerMobile.instance.OnMenu = true;
    }

    public void CloseHelpScreen()
    {
        foreach (GameObject scene in helpImages)
        {
            scene.SetActive(false);
        }
        helpImages[0].SetActive(true);
        helpIndx = 0;
        previousPageButton.gameObject.SetActive(false);
        nextPageButton.gameObject.SetActive(true);

        _helpScreenGO.SetActive(false);
        GameManagerMobile.instance.OnMenu = lastOnMenu;
    }

    public void NextPage()
    {
        helpImages[helpIndx].SetActive(false);
        helpIndx++;
        if (helpIndx == helpImages.Length - 1)
        {
            nextPageButton.gameObject.SetActive(false);
        }
        else if (helpIndx >= helpImages.Length)
        {
            helpIndx = helpImages.Length - 1;


        }

        previousPageButton.gameObject.SetActive(true);
        helpImages[helpIndx].SetActive(true);
    }

    public void PreviousPage()
    {
        helpImages[helpIndx].SetActive(false);
        helpIndx--;
        if (helpIndx == 0)
        {
            previousPageButton.gameObject.SetActive(false);
        }
        else if (helpIndx < 0)
        {
            helpIndx = 0;

        }
        nextPageButton.gameObject.SetActive(true);
        helpImages[helpIndx].SetActive(true);
    }
}

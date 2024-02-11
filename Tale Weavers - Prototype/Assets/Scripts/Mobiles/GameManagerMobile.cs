using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerMobile : MonoBehaviour
{
    public static GameManagerMobile instance;
    public PlayerMobileController player;

    public CanvasControllerMobile canvasC;

    public string nextLevelName;
    public bool _onMenu;

    [HideInInspector] public Timer timer;

    [SerializeField] private float maxTime;
    public bool OnMenu
    {
        get { return _onMenu; }
        set
        {
            _onMenu = value;
            if (value)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }

    [SerializeField] private int levelIndx;

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


    // Start is called before the first frame update
    void Start()
    {

        canvasC.Initiate();
        SetUpMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpMusic()
    {
        AudioManager.instance.InilitializeVolumen();
        AudioManager.instance.Stop("musicaVictoria");
        AudioManager.instance.Stop("musicaDerrota");
        AudioManager.instance.Stop("musicaMenu");
        AudioManager.instance.Stop("musicaAtrapado");
        AudioManager.instance.Play("musicaNivel");
    }

    public void WinScreen()
    {
        AudioManager.instance.Stop("musicaNivel");
        AudioManager.instance.Play("musicaVictoria");
        canvasC.EndLevel();
        //AudioManager.instance.Stop("musicaAtrapado");
        //AudioManager.instance.Play("musicaDerrota");
    }


    public void RestartLevel()
    {
        StartCoroutine(SetupLevel());
        Time.timeScale = 0.0f;
    }

    private IEnumerator SetupLevel()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        string name = SceneManager.GetActiveScene().name;
        LevelManager.instance.LoadScene(name);
        Time.timeScale = 1.0f;
    }

    public void NextLevel()
    {
        ProgressManager.instance.UpdateLevel(levelIndx);
        LevelManager.instance.LoadSceneCoroutine(nextLevelName);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame()
    {
        timer.timer = maxTime;
        player.gameObject.SetActive(true);
        timer.StartTimer();
        OnMenu = false;
        Vibration.Vibrate(100);
    }

    public void EndLevelLost()
    {
        
        Time.timeScale = 0.0f;
        canvasC.LostLevel();
        AudioManager.instance.Stop("musicaNivel");
        AudioManager.instance.Play("musicaDerrota");
        Vibration.Vibrate(100);
    }


}

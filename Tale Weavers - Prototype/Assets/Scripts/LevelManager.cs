using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private GameObject _loadingScreen;
    private Image _progressBar;
    private float _target;
    

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(gameObject);
    }
    public void Start()
    {

    }

    public void LoadScene(string esceneIndx)
    {
        SceneManager.LoadScene(esceneIndx);
    }

    public void LoadSceneCoroutine(string esceneIndx)
    {
        _progressBar.fillAmount = 0;
        _loadingScreen.SetActive(true);
        StartCoroutine(LoadLevelASync(esceneIndx));
    }

    public async void LoadSceneA(string esceneIndx)
    {
        _target = 0;
        _progressBar.fillAmount = 0;
        var scene = SceneManager.LoadSceneAsync(esceneIndx);
        scene.allowSceneActivation = false;

        _loadingScreen.SetActive(true);

        do
        {
            await Task.Delay(100);
            _target = scene.progress;
        } while (scene.progress < 0.9f);

  
        scene.allowSceneActivation = true;
        _loadingScreen.SetActive(false);
    }

    private void Update()
    {
        //_progressBar.fillAmount = Mathf.MoveTowards(_progressBar.fillAmount,_target, 3*Time.deltaTime);
    }

    public void AddReferneces(GameObject loadScreen, Image bar)
    {
        _loadingScreen = loadScreen;
        _progressBar = bar;
    }

    IEnumerator LoadLevelASync(string levelName)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelName);

        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            _progressBar.fillAmount = progressValue;
            yield return null;
        }
        _loadingScreen.SetActive(false);
    }
}

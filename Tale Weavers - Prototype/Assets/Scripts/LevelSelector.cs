using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{

    public Button[] levelButtons;

    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Image _progressBar;
    private float _target;

    private void Start()
    {
        if (!AudioManager.instance.IsPlaying("musicaMenu")) AudioManager.instance.Play("musicaMenu");
        AudioManager.instance.Stop("musicaVictoria");
        AudioManager.instance.Stop("musicaDerrota");
        AudioManager.instance.Stop("musicaNivel");
        AudioManager.instance.Stop("musicaAtrapado");

        for(int i = -1; i < ProgressManager.instance.lastLevelCompleted; i++)
        {
            levelButtons[i+1].interactable = true;
        }
    }

    public void LevelSelect(string level)
    {
        _progressBar.fillAmount = 0;
        _loadingScreen.SetActive(true);
        StartCoroutine(LoadLevelASync(level));
        //SceneManager.LoadScene(level);
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


    public void Salir()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(int esceneIndx)
    {
        SceneManager.LoadScene(esceneIndx);
    }

    public async void LoadSceneA(int esceneIndx)
    {
        var scene = SceneManager.LoadSceneAsync(esceneIndx);
        scene.allowSceneActivation = false;

        //do
        //{
        //    await Task.Delay(1000);
        //    //_progressbard.fillAmount = scene.progress;
        //} while (scene.progress < 0.9f);

        //await.TaskDelay(100);

        //scene.allowSceneActivation = true;
        //_loaderCanvas.SetActive(false);
    }
}

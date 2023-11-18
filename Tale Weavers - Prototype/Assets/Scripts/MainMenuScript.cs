using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
   private void Start()
    {
        AudioManager.instance.Play("musicaMenu");
    }
   public void Play()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

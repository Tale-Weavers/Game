using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
   private void Start()
    {
        if (!AudioManager.instance.IsPlaying("musicaMenu")) AudioManager.instance.Play("musicaMenu");
        AudioManager.instance.Stop("musicaVictoria");
        AudioManager.instance.Stop("musicaDerrota");
        AudioManager.instance.Stop("musicaNivel");
        AudioManager.instance.Stop("musicaAtrapado");
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

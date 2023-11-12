using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
   public void Play()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    public void QuitGame()
    {
        Debug.Log("Adios adios");
        Application.Quit();
    }
}
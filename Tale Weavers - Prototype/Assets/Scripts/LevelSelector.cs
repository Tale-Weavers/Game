using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{

    public Button[] levelButtons;




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
        SceneManager.LoadScene(level);
    }

    public void Salir()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
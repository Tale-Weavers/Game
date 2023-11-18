using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{

    public Button Tutorial1;
    public Button Tutorial2;
    public Button Tutorial3;

    public Button Nivel1;
    public Button Nivel2;
    public Button Nivel3;

    private void Start()
    {
        if (!AudioManager.instance.IsPlaying("musicaMenu")) AudioManager.instance.Play("musicaMenu");
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
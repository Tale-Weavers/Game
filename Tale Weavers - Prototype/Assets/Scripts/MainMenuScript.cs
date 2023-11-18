using DG.Tweening;
using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private RectTransform optionsMenu;
    [SerializeField] private CanvasGroup optionsMenuImage;

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

    public void OpenOptions()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(optionsMenuImage.DOFade(1, 0.5f).SetEase(Ease.InCubic));
    }

    public void CloseOptions()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(optionsMenuImage.DOFade(0, 0.5f).SetEase(Ease.InCubic));
    }
}

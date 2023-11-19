using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private RectTransform optionsMenu;
    [SerializeField] private CanvasGroup optionsMenuImage;

    public Slider generalAudio;
    public Slider Music;
    public Slider SFX;


    private void Start()
    {
        generalAudio.onValueChanged.AddListener(AudioManager.instance.GeneralSound);
        SFX.onValueChanged.AddListener(AudioManager.instance.SFXSound);
        Music.onValueChanged.AddListener(AudioManager.instance.MusicSound);
        AudioManager.instance.sliderGeneral = generalAudio;
        AudioManager.instance.sliderSFX = SFX;
        AudioManager.instance.sliderMusic = Music;
        AudioManager.instance.InilitializeVolumen();

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

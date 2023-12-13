using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    #region Singleton

    public static AudioManager instance;

    public Slider sliderGeneral, sliderMusic, sliderSFX;

    public bool loggedIn;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this); //Por si tenemos musica y queremos cambiar de escenay no se resetee

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;

            s.source.dopplerLevel = s.dopplerLevel;

            s.source.spatialBlend = s.spatialBlend;

            s.source.rolloffMode = s.volumeRolloff;

            s.source.minDistance = s.minDistance;

            s.source.maxDistance = s.maxDistance;

            if (s.audioType == Sound.AudioTypes.SoundEffect)
                s.source.outputAudioMixerGroup = SoundsEffectsMixerGroup;
            else if (s.audioType == Sound.AudioTypes.Music)
                s.source.outputAudioMixerGroup = MusicMixerGroup;
            else
                s.source.outputAudioMixerGroup = GeneralMixerGroup;

            if (s.playOnAwake)
                s.source.Play();
        }
    }



    private void Start()
    {

    }

    //Inicializa los volumenes segun los ajustes del jugador o al maximo si no los ha tocado
    public void InilitializeVolumen()
    {

        sliderGeneral.value = PlayerPrefs.GetFloat(masterMixer, 100.0f);
        sliderMusic.value = PlayerPrefs.GetFloat(musicMixer, 100.0f);
        sliderSFX.value = PlayerPrefs.GetFloat(sfxMixer, 100.0f);
        if (sliderGeneral.value == 0)
        {
            GeneralMixerGroup.audioMixer.SetFloat(masterMixer, -80);
        }
        else
        {
            GeneralMixerGroup.audioMixer.SetFloat(masterMixer, Mathf.Log10(sliderGeneral.value / 100) * 20);
        }
        if (sliderMusic.value == 0)
        {
            GeneralMixerGroup.audioMixer.SetFloat(musicMixer, -80);

        }
        else
        {
            GeneralMixerGroup.audioMixer.SetFloat(musicMixer, Mathf.Log10(sliderMusic.value / 100) * 20);

        }
        if (sliderSFX.value == 0)
        {
            GeneralMixerGroup.audioMixer.SetFloat(musicMixer, -80);
        }
        else
        {
            GeneralMixerGroup.audioMixer.SetFloat(musicMixer, Mathf.Log10(sliderSFX.value / 100) * 20);
        }


    }

    #endregion Singleton

    [Tooltip("Lista de los sonidos que se van a usar")]
    public Sound[] sounds;

    [Space(10)]
    [Header("Mixers")]
    public string masterMixer;
    public string sfxMixer;
    public string musicMixer;
    [SerializeField]
    [Tooltip("Grupo del mixer que servira para subir o bajar el volumen general")]
    private AudioMixerGroup GeneralMixerGroup;

    [SerializeField]
    [Tooltip("Grupo del mixer que servira para subir o bajar el volumen de la musica")]
    private AudioMixerGroup MusicMixerGroup;

    [SerializeField]
    [Tooltip("Grupo del mixer que servira para subir o bajar el volumen de los efectos de sonido")]
    private AudioMixerGroup SoundsEffectsMixerGroup;

    //Inicia el sonido x
    /// <summary>
    /// Plays a sound.
    /// </summary>
    /// <param name="name">Name of the sound</param>
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            //Debug.LogError("Sound " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    //Para el sonido x
    /// <summary>
    /// Stops playing a sound.
    /// </summary>
    /// <param name="name">Name of the sound</param>
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Stop();
    }

    //Detecta si el sonido x esta sonando
    public bool IsPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            //Debug.LogError("Sound " + s.name + " not found!");
            return false;
        }
        if (s.source.isPlaying)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Metodo que controla el volumen general atraves del slider y lo guarda
    public void GeneralSound(float sliderValue)
    {
        if (sliderValue == 0)
        {
            GeneralMixerGroup.audioMixer.SetFloat(masterMixer, -80);
            
        }
        else
        {
            GeneralMixerGroup.audioMixer.SetFloat(masterMixer, Mathf.Log10(sliderValue / 100) * 20);
        }

        PlayerPrefs.SetFloat(masterMixer, sliderValue);
        PlayerPrefs.Save();
    }

    //Metodo que controla el volumen sfx atraves del slider y lo guarda
    public void SFXSound(float sliderValue)
    {
        if (sliderValue == 0)
        {
            SoundsEffectsMixerGroup.audioMixer.SetFloat(sfxMixer, -80);
        }
        else
        {
            SoundsEffectsMixerGroup.audioMixer.SetFloat(sfxMixer, Mathf.Log10(sliderValue / 100) * 20);
        }

        PlayerPrefs.SetFloat(sfxMixer, sliderValue);
        PlayerPrefs.Save();
    }

    //Metodo que controla el volumen musica atraves del slider y lo guarda
    public void MusicSound(float sliderValue)
    {
        if(sliderValue == 0)
        {
            MusicMixerGroup.audioMixer.SetFloat(musicMixer, -80);
        }
        else
        {
            SoundsEffectsMixerGroup.audioMixer.SetFloat(musicMixer, Mathf.Log10(sliderValue / 100) * 20);
        }

        PlayerPrefs.SetFloat(musicMixer, sliderValue);
        PlayerPrefs.Save();
    }

    //Metodo para resetear los ajustes
    public void ResetAjustes()
    {
        sliderGeneral.value = 100;
        sliderMusic.value = 100;
        sliderSFX.value = 100;
    }
    

    public void PlaySchedule(string name,float time)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            //Debug.LogError("Sound " + name + " not found!");
            return;
        }
        s.source.PlayScheduled(AudioSettings.dspTime +time);
    }
}
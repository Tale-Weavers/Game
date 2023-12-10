using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VidPlayer : MonoBehaviour
{
    [SerializeField] string videoFileName;
    VideoPlayer player;
    public GameObject playerCanvas;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<VideoPlayer>();
        
        if (player)
        {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
            player.url = videoPath;
            player.Prepare();
            player.prepareCompleted += OnVideoPrepared;
            player.loopPointReached += OnVideoEnd;
        }
    }


    void OnVideoPrepared(VideoPlayer vp)
    {
        if (SceneManager.GetActiveScene().name != "Nivel 21")
        {
            PlayVideo();
        }
    }
    public void PlayVideo()
    {
        if (player)
        {
            player.Play();
        }
    }
    void OnVideoEnd(VideoPlayer vp)
    {
        vp.Stop();
        playerCanvas.SetActive(false);
        if (SceneManager.GetActiveScene().name == "Nivel 21")
        {
            GameManager.instance.NextLevel();
        }
    }

}

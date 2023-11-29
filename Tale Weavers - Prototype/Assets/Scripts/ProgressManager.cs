using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager instance;

    public int lastLevelCompleted;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        lastLevelCompleted = PlayerPrefs.GetInt("LastLevelCompleted");

    }

    void Start()
    {
    }

    public void UpdateLevel(int levelIndx)
    {
        if(levelIndx>lastLevelCompleted)
        {
            lastLevelCompleted= levelIndx;
            PlayerPrefs.SetInt("LastLevelCompleted", lastLevelCompleted);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager instance;

    //public int[] starsOnLevels;

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

    //private void SaveArray<T>(string key, T[] array)
    //{
    //    // Convertir el array a una cadena JSON
    //    string jsonArray = JsonUtility.ToJson(array);

    //    // Guardar la cadena JSON en PlayerPrefs
    //    PlayerPrefs.SetString(key, jsonArray);
    //    PlayerPrefs.Save();
    //}

    //private T[] LoadArray<T>(string key)
    //{
    //    Obtener la cadena JSON desde PlayerPrefs
    //    string jsonArray = PlayerPrefs.GetString(key, null);

    //    T[] loadedArray = null;

    //    if (jsonArray != null)
    //    {
    //        loadedArray = JsonUtility.FromJson<T[]>(jsonArray);
    //    }


    //    return loadedArray;
    //}
}

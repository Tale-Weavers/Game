using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public float timer = 0;

    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private bool timerEnabled;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerEnabled)
        {
            timer -= Time.deltaTime;

            text.text = "" + timer.ToString("f1");
            if (timer <= 0)
            {
                GameManagerMobile.instance.EndLevelLost();
                timerEnabled = false;
            }
        }

    }

    public void StartTimer()
    {
        timerEnabled = true;
    }
}

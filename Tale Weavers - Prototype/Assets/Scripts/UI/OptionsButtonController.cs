using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!GameManager.instance.canvasC.GetOpenSettings())
            {
                GameManager.instance.canvasC.OpenSettings();
            }
            else
            {
                GameManager.instance.canvasC.CloseSettings();
            }
        }
    }
}

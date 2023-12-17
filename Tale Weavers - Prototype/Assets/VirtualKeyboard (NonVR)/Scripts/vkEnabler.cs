using System.IO;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class vkEnabler : MonoBehaviour
{

    public bool isMobile;

#if !UNITY_EDITOR && UNITY_WEBGL
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern bool IsMobile();
#endif

    private void CheckIfMobile()
    {
        isMobile = false;

#if !UNITY_EDITOR && UNITY_WEBGL
        isMobile = IsMobile();
#endif

       
    }

    // Start is called before the first frame update
    private void Start()
    {
        CheckIfMobile();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void ShowVirtualKeyboard()
    {
        if(isMobile)
        {
            TNVirtualKeyboard.instance.ShowVirtualKeyboard();
            TNVirtualKeyboard.instance.targetText = gameObject.GetComponent<TMP_InputField>();
        }

    }


}
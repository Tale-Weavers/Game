using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TNVirtualKeyboard : MonoBehaviour
{
	
	public static TNVirtualKeyboard instance;
	
	public string words = "";
	
	public GameObject vkCanvas;
	
	public TMP_InputField targetText;

	private char[] chars;

	
	
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
		HideVirtualKeyboard();
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void KeyPress(string k){
		if(targetText.gameObject.name == "AgeInput")
		{
			words = targetText.text;
			chars = k.ToCharArray();

            if (chars[0] >'0' && chars[0]<'9')
			{
                words += k;
                targetText.text = words;
            }
		}
		else
		{
            words = targetText.text;
            words += k;
            targetText.text = words;
        }

	}
	
	public void Del(){
		words = targetText.text;
        words = words.Remove(words.Length - 1, 1);
		targetText.text = words;	
	}
	
	public void ShowVirtualKeyboard(){
		vkCanvas.SetActive(true);
	}
	
	public void HideVirtualKeyboard(){
		words = "";
		vkCanvas.SetActive(false);
	}
}

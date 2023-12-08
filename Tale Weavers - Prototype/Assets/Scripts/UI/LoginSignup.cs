using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoginSignup : MonoBehaviour
{
    [Header("Login Attributes")]
    [SerializeField] TMP_InputField loginUsernameInput;
    [SerializeField] TMP_InputField loginPasswordInput;
    [SerializeField] Button sendLoginData;

    [Header("Signup Attributes")]
    [SerializeField] TMP_InputField signupUsernameInput;
    [SerializeField] TMP_InputField signupPasswordInput;
    [SerializeField] TMP_InputField signupAgeInput;
    [SerializeField] TMP_Dropdown signupGenderInput;
    [SerializeField] Button sendSignupData;

    // Start is called before the first frame update
    void Start()
    {
        sendSignupData.onClick.AddListener(SendSignupToDatabase);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SendSignupToDatabase()
    {
        string username = signupUsernameInput.text;
        string password = signupPasswordInput.text;
        string ageText = signupAgeInput.text;
        int age = int.Parse(ageText);
        int gender = signupGenderInput.value;

        if (age > 120)
        {
            Debug.Log("Invalid age");
            return;
        }

        Debug.Log(username + " " + password + " " + age + " " + gender);
        //DatabaseManager.instance.StartQueryCoroutine(username);
    }
}

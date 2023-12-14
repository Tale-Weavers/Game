using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Rendering;

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


    [Header("Warning Attributes")]
    [SerializeField] TextMeshProUGUI errorText;
    [SerializeField] GameObject warningGO;
    [SerializeField] Button warningButton;

    // Start is called before the first frame update
    void Start()
    {
        sendSignupData.onClick.AddListener(CheckSignup);
        sendLoginData.onClick.AddListener(CheckLogin);
        warningButton.onClick.AddListener(HideWarning);
        if(AudioManager.instance.loggedIn)
        {
            SuccessLogin();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CheckSignup()
    {
        string username = signupUsernameInput.text;
        string password = signupPasswordInput.text;
        string ageText = signupAgeInput.text;
        int age = int.Parse(ageText);
        int gender = signupGenderInput.value;

        if (age > 120 || username=="" || password==""||ageText=="")
        {
            ShowError();
            return;
        }

        Debug.Log(username + " " + password + " " + age + " " + gender);
        DatabaseManager.instance.StartQueryCoroutine(username, password, age, gender);
    }

    void CheckLogin()
    {
        string username = loginUsernameInput.text;
        string password = loginPasswordInput.text;
        if(username == "" || password == "")
        {
            ShowError();
            return;
        }
        DatabaseManager.instance.SendLoginDataJSON(username, password);

    }


    public void SuccessLogin()
    {
        AudioManager.instance.loggedIn = true;
        Debug.Log("SuccessLogin");
        gameObject.SetActive(false);
    }

    public void FailureLogin()
    {
        Debug.Log("FailureLogin");
        errorText.text = "Wrong username or password";
        warningGO.SetActive(true);
    }

    public void SuccessRegister()
    {
        AudioManager.instance.loggedIn = true;
        Debug.Log("SuccessRegister");
        gameObject.SetActive(false);
    }

    public void FailureRegister()
    {
        Debug.Log("FailureRegister");
        errorText.text = "Username already registered";
        warningGO.SetActive(true);
    }

    public void ShowError()
    {
        errorText.text = "Invalid Fields";
        warningGO.SetActive(true);

    }

    public void HideWarning()
    {
        warningGO.SetActive(false);
    }




    //IEnumerator DisableErrorText()
    //{
    //    errorText.gameObject.SetActive(true);
    //    yield return new WaitForSeconds(errorTime);
    //    errorText.gameObject.SetActive(false);
    //}

}

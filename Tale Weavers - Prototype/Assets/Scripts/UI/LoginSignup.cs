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

    [SerializeField] TextMeshProUGUI errorText;
    [SerializeField] float errorTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        sendSignupData.onClick.AddListener(CheckSignup);
        sendLoginData.onClick.AddListener(CheckLogin);
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

        if (age > 120)
        {
            Debug.Log("Invalid age");
            return;
        }

        Debug.Log(username + " " + password + " " + age + " " + gender);
        DatabaseManager.instance.StartQueryCoroutine(username, password, age, gender);
    }

    void CheckLogin()
    {
        string username = loginUsernameInput.text;
        string password = loginPasswordInput.text;
        DatabaseManager.instance.SendLoginDataJSON(username, password);

    }


    public void SuccessLogin()
    {
        Debug.Log("SuccessLogin");
        gameObject.SetActive(false);
    }

    public void FailureLogin()
    {
        Debug.Log("FailureLogin");
        errorText.text = "Wrong username or password";
        StartCoroutine(DisableErrorText());
    }

    public void SuccessRegister()
    {
        Debug.Log("SuccessRegister");
        gameObject.SetActive(false);
    }

    public void FailureRegister()
    {
        Debug.Log("FailureRegister");
        errorText.text = "Username already registered";
        StartCoroutine(DisableErrorText());
    }

    IEnumerator DisableErrorText()
    {
        errorText.gameObject.SetActive(true);
        yield return new WaitForSeconds(errorTime);
        errorText.gameObject.SetActive(false);
    }

}

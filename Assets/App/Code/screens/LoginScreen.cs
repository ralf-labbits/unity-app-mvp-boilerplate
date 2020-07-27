using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class LoginScreen : Menu<LoginScreen>
{
    public Button btnLogin;
    public InputField inputEmail;
    public InputField inputPassword;
    public GameObject loading;


    public LoginView view;

    public void OpenMainScreen()
    {
        MainScreen.Open();
    }

    private void OnEnable()
    {
        
        view = new LoginView();

    }

    void OnDisable()
    {
        view.Destroy();
        view = null;
    }
}

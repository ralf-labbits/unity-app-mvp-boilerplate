using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class MainScreen : Menu<MainScreen>
{
    public Button btnNext;
    public Button btnLogout;

    private void Start()
    {
        btnNext.onClick.AddListener(NextScreen);

        btnLogout.onClick.AddListener(Logout);
    }

    public void NextScreen()
    {
        Screen1.Open();
    }

    public void Logout()
    {
        UserSession.ResetUserAccess();
        LoginScreen.Open();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class SplashScreen : Menu<SplashScreen>
{
    void Start()
    {
        if (UserSession.IsUserLogged())
        {
            MainScreen.Open();
        } else
        {
            LoginScreen.Open();
        }
        
    }
}

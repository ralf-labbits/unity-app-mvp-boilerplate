using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class Screen1 : Menu<Screen1>
{
    public Button btnNext;
    public Button btnBack;

    private void Start()
    {
        btnNext.onClick.AddListener(NextScreen);
        btnBack.onClick.AddListener(BackScreen);
    }

    public void NextScreen()
    {
        Screen2.Open();
    }

    public void BackScreen()
    {
        MainScreen.Open();
    }
}

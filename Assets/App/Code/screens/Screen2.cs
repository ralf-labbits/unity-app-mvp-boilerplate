using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class Screen2 : Menu<Screen2>
{
    public Button btnBack;

    private void Start()
    {
        btnBack.onClick.AddListener(BackScreen);
    }

    public void BackScreen()
    {
        Screen1.Open();
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectPlayers : MonoBehaviour
{
    int buttonIndex = 0;

    Button[] buttons;
    public Button SecretBackButton;
    private bool IgnoreFirstUpdate = true;
    void Awake()
    {
        buttons = GetComponentsInChildren<Button>();
    }

    void Start()
    {
        GotoSelectMenu();
    }

    public void GotoSelectMenu()
    {
        buttonIndex = 0;
        buttons[buttonIndex].Select();
        Debug.Log(buttons[buttonIndex]);
        IgnoreFirstUpdate = true;
    }

    void Update()
    {
        if (IgnoreFirstUpdate)
        {
            IgnoreFirstUpdate = false;
            return;
        }

        if (hinput.anyGamepad.leftStick.down.justPressed)
        {
            if (buttonIndex < buttons.Length - 1)
            {
                buttonIndex++;
                buttons[buttonIndex].Select();
            }
        }
        if (hinput.anyGamepad.leftStick.up.justPressed)
        {
            if (buttonIndex > 0)
            {
                buttonIndex--;
                buttons[buttonIndex].Select();
            }
        }
        if (hinput.anyGamepad.A.justPressed)
        {
            buttons[buttonIndex].onClick.Invoke();
        }
        if (hinput.anyGamepad.B.justPressed)
        {
            SecretBackButton.onClick.Invoke();
        }
    }
}

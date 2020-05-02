using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SelectPlayers : MonoBehaviour
{
    int buttonIndex = 0;

    Button[] buttons;
    public Button SecretBackButton;
    private float IgnoreTimer = 0.0f;
    private bool IgnoreFirstUpdate = true;
    void Awake()
    {
        buttons = GetComponentsInChildren<Button>();
    }

    public void GotoSelectMenu()
    {
        gameObject.SetActive(true);
        buttonIndex = 0;
        IgnoreFirstUpdate = true;
        IgnoreTimer = 0.0f;
    }

    void Update()
    {
        if (IgnoreFirstUpdate)
        {
            IgnoreTimer += Time.deltaTime;
            if (IgnoreTimer > 0.25f)
            {
                buttons[buttonIndex].Select();
                IgnoreFirstUpdate = false;
            }
            return;
        }

        var gamepad = Gamepad.current;
        if (gamepad == null)
            return; // No gamepad connected.

        if (gamepad.leftStick.down.wasPressedThisFrame || Keyboard.current.sKey.wasPressedThisFrame || Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            if (buttonIndex < buttons.Length - 1)
            {
                buttonIndex++;
                buttons[buttonIndex].Select();
            }
        }
        else if (gamepad.leftStick.up.wasPressedThisFrame || Keyboard.current.wKey.wasPressedThisFrame || Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            if (buttonIndex > 0)
            {
                buttonIndex--;
                buttons[buttonIndex].Select();
            }
        }

        if (gamepad.aButton.wasPressedThisFrame || Keyboard.current.spaceKey.wasPressedThisFrame || Keyboard.current.enterKey.wasPressedThisFrame)
        {
            buttons[buttonIndex].onClick.Invoke();
        }
        else if (gamepad.bButton.wasPressedThisFrame || Keyboard.current.backspaceKey.wasPressedThisFrame || Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            SecretBackButton.onClick.Invoke();
        }
    }
}

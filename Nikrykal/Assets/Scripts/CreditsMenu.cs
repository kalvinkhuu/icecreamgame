using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CreditsMenu : MonoBehaviour
{
    Button BackButton;
    private bool IgnoreFirstUpdate = true;
    private float IgnoreTimer = 0.0f;

    void Awake()
    {
        BackButton = GetComponentInChildren<Button>();
    }

    void Start()
    {
    }

    public void GotoCreditsMenu()
    {
        gameObject.SetActive(true);
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
                BackButton.Select();
                IgnoreFirstUpdate = false;
            }
            return;
        }

        var gamepad = Gamepad.current;
        if (gamepad == null)
            return; // No gamepad connected.

        if (gamepad.bButton.wasPressedThisFrame || Keyboard.current.backspaceKey.wasPressedThisFrame || Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            BackButton.onClick.Invoke();
        }

        //Vector2 move = gamepad.leftStick.ReadValue();
    }
}

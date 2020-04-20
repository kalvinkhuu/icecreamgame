using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsMenu : MonoBehaviour
{
    Button BackButton;
    private bool IgnoreFirstUpdate = true;

    void Awake()
    {
        BackButton = GetComponentInChildren<Button>();
    }

    void Start()
    {
        GotoCreditsMenu();
    }

    public void GotoCreditsMenu()
    {
        BackButton.Select();
        IgnoreFirstUpdate = true;
    }

    void Update()
    {
        if (IgnoreFirstUpdate)
        {
            IgnoreFirstUpdate = false;
            return;
        }

        if (hinput.anyGamepad.A.justPressed || hinput.anyGamepad.B.justPressed)
        {
            BackButton.onClick.Invoke();
        }
    }
}

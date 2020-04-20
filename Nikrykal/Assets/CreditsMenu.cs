using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsMenu : MonoBehaviour
{
    Button BackButton;

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
    }

    void Update()
    {
        if (hinput.anyGamepad.A.justPressed || hinput.anyGamepad.B.justPressed)
        {
            BackButton.onClick.Invoke();
        }
    }
}

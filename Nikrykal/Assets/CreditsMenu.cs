using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        GotoCreditsMenu();
    }

    public void GotoCreditsMenu()
    {
        BackButton.Select();
        IgnoreFirstUpdate = true;
        IgnoreTimer = 0.0f;
    }

    void Update()
    {
        if (IgnoreFirstUpdate)
        {
            IgnoreTimer += Time.deltaTime;
            if (IgnoreTimer > 0.5f)
            {
                IgnoreFirstUpdate = false;
            }
            return;
        }

        if (hinput.anyGamepad.A.justPressed || hinput.anyGamepad.B.justPressed)
        {
            BackButton.onClick.Invoke();
        }
    }
}

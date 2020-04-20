using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MainMenu : MonoBehaviour
{
    public static int ChosenNumPlayers = 4;

    Button PlayButton;
    Button CreditsButton;
    bool PlaybuttonSelected = true;

    void Awake()
    {
        Button [] buttons = GetComponentsInChildren<Button>();
        PlayButton = buttons[0];
        CreditsButton = buttons[1];
    }

    void Start()
    {
        PlayButton.Select();
    }

    public void BackToMainMenu()
    {
        PlayButton.Select();
    }

    public void BackToMainMenuFromCredits()
    {
        CreditsButton.Select();
    }

    void Update()
    {
        if (hinput.anyGamepad.leftStick.down.justPressed)
        {
            CreditsButton.Select();
        }
        if (hinput.anyGamepad.leftStick.up.justPressed)
        {
            PlayButton.Select();
        }
        if (hinput.anyGamepad.A.justPressed)
        {
            if (PlaybuttonSelected)
            {
                PlayButton.onClick.Invoke();
            }
            else
            {
                CreditsButton.onClick.Invoke();
            }
        }
    }

    public void GoToSelectMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayGame(int NumPlayers)
    {
        ChosenNumPlayers = NumPlayers;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
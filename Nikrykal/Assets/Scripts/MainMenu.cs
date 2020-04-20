using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MainMenu : MonoBehaviour
{
    public static int ChosenNumPlayers = 4;

    Button[] buttons;
    int buttonIndex = 0;

    void Awake()
    {
        buttons = GetComponentsInChildren<Button>();
    }

    void Start()
    {
        BackToMainMenu();
    }

    public void BackToMainMenu()
    {
        buttonIndex = 0;
        buttons[buttonIndex].Select();
    }

    public void BackToMainMenuFromCredits()
    {
        buttonIndex = 2;
        buttons[buttonIndex].Select();
    }

    public void BackToMainMenuFromTutorial() 
    {
        buttonIndex = 1;
        buttons[buttonIndex].Select();
    }
     

    void Update()
    {
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
        if (hinput.anyGamepad.A.justReleased)
        {
            buttons[buttonIndex].onClick.Invoke();
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
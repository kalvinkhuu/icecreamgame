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

    private bool IgnoreFirstUpdate = true;
    private float IgnoreTimer = 0.0f;

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
        gameObject.SetActive(true);
        buttonIndex = 0;
    }

    public void BackToMainMenuFromCredits()
    {
        gameObject.SetActive(true);
        buttonIndex = 2;
    }

    public void BackToMainMenuFromTutorial() 
    {
        gameObject.SetActive(true);
        buttonIndex = 1;
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
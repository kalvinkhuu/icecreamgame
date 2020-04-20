using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Countdown : MonoBehaviour
{
    private TextMeshProUGUI TimeRemaining;
    void Awake()
    {
        TimeRemaining = GetComponent<TextMeshProUGUI>();
        TimeRemaining.enabled = false;
    }

    void Update()
    {
        float DurationOfGame = GameManager.GameTimeInSeconds;
        float Last10seconds = GameManager.GameTimeInSeconds - 10.0f;
        if (Time.time > DurationOfGame)
        {
            TimeRemaining.text = "Time's up!";
        }
        else if (Time.time > Last10seconds)
        {
            TimeRemaining.enabled = true;
            TimeRemaining.text = ((int)(DurationOfGame - Time.time)).ToString();
        }
    }
}


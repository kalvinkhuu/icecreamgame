using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Countdown : MonoBehaviour
{
    private TextMeshProUGUI TimeRemaining;
    float TimeAtStart = 0.0f;
    bool TimeAtStartSet = false;
    void Awake()
    {
        TimeRemaining = GetComponent<TextMeshProUGUI>();
        TimeRemaining.enabled = false;
        TimeAtStartSet = false;
    }

    void Update()
    {
        if (!TimeAtStartSet)
        {
            TimeAtStart = Time.time;
            TimeAtStartSet = true;
        }

        float DurationOfGame = GameManager.GameTimeInSeconds;
        float Last10seconds = GameManager.GameTimeInSeconds - 10.0f;
        float GameTime = Time.time - TimeAtStart;
        if (GameTime >= DurationOfGame)
        {
            TimeRemaining.text = "Time's up!";
        }
        else if (GameTime > Last10seconds)
        {
            TimeRemaining.enabled = true;
            int TimeRemainingValue = ((int)(DurationOfGame - GameTime));
            if (TimeRemainingValue == 0)
            {
                TimeRemainingValue = 1;
            }
            TimeRemaining.text = TimeRemainingValue.ToString();
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherSystem : MonoBehaviour
{
    private float TimeElapsed;
    private float TimeForSunrise = 0.0f;
    public float DurationOfGame = GameManager.GameTimeInSeconds;
    public float RotationForSunrise;
    public static float CurrentSunRotationX;
   

    // Start is called before the first frame update
    void Start()
    {
        TimeElapsed = TimeForSunrise;

    }

    // Update is called once per frame
    void Update()
    {
        TimeElapsed += Time.deltaTime;
        CurrentSunRotationX = RotationForSunrise + 180.0f * TimeElapsed / (DurationOfGame);
        transform.rotation = Quaternion.AngleAxis(CurrentSunRotationX, new Vector3(1.0f,0.0f,0.0f)) * Quaternion.AngleAxis(20.0f, new Vector3(0.0f, 1.0f, 1.0f)); ;
        
    }
}

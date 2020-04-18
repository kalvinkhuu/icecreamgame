using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherSystem : MonoBehaviour
{
    private float TimeElapsed;
    private float TimeForSunrise = 0.0f;
    private float TimeForSunset = 600.0f;
    public float DurationOfGame;
    public float RotationForSunrise;

    // Start is called before the first frame update
    void Start()
    {
        TimeElapsed = TimeForSunrise;

    }

    // Update is called once per frame
    void Update()
    {
        TimeElapsed += Time.deltaTime;
        float NewXRotation = RotationForSunrise + 180.0f * TimeElapsed / (DurationOfGame);
        transform.rotation = Quaternion.AngleAxis(NewXRotation, new Vector3(1.0f,0.0f,0.0f));
    }
}

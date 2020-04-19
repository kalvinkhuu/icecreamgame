using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamCone : MonoBehaviour
{
    public GameObject[] Balls;

    private float TimeElapsed;

    private GameObject CurrentBall;
    private int CurrentBallIndex;
    private int NumBalls;
    public float TimePerScoopDeathNormal = 10.0f;
    public float TimePerScoopDeathHot = 7.0f;
    public bool IsSunLeader;
    
    // Start is called before the first frame update
    void Start()
    {
        PickupNewIceCream();
    }

    public void PickupNewIceCream()
    {
        gameObject.SetActive(true);
        TimeElapsed = 0.0f;
        CurrentBallIndex = 0;
        CurrentBall = Balls[CurrentBallIndex];
        NumBalls = Balls.Length;
        foreach (GameObject Ball in Balls)
        {
            Ball.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
       TimeElapsed += Time.deltaTime;
       //Debug.Log("Time Elapsed = " + TimeElapsed.ToString());
        if ((WeatherSystem.CurrentSunRotationX >= 75 && WeatherSystem.CurrentSunRotationX <= 95) || IsSunLeader) 
        {
            if (TimeElapsed >= TimePerScoopDeathHot)
            {
                CurrentBall.SetActive(false);
                TimeElapsed = 0.0f;
                if (CurrentBallIndex < Balls.Length - 1)
                {
                    CurrentBallIndex++;
                    NumBalls--;
                    CurrentBall = Balls[CurrentBallIndex];
                }
            }
        }
        else
        {
            if (TimeElapsed >= TimePerScoopDeathNormal)
            {
                CurrentBall.SetActive(false);
                TimeElapsed = 0.0f;
                if (CurrentBallIndex < Balls.Length - 1)
                {
                    CurrentBallIndex++;
                    NumBalls--;
                    CurrentBall = Balls[CurrentBallIndex];
                }
            }
        }
    }

    public void GiveIceCreamToChild()
    {
        NumBalls = 0;
        gameObject.SetActive(false);
    }

    public int GetNumBalls()
    {
        return NumBalls;
    }
}

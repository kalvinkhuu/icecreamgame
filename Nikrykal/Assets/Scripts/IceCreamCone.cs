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
    private IceCreamSplat Splat;
    
    // Start is called before the first frame update
    void Awake()
    {
        NumBalls = 0;
        Splat = GetComponentInChildren<IceCreamSplat>();
    }

    void Start()
    {
        gameObject.SetActive(false);   
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

    private void SplatBall()
    {
        if (CurrentBallIndex < Balls.Length)
        {
            if (CurrentBallIndex == 0)
            {
                Splat.SplatVanilla();
            }
            else if (CurrentBallIndex == 1)
            {
                Splat.SplatStrawberry();
            }
            else if (CurrentBallIndex == 2)
            {
                Splat.SplatChocolate();
            }
            CurrentBall.SetActive(false);
            TimeElapsed = 0.0f;
            CurrentBallIndex++;
            NumBalls--;
            if (CurrentBallIndex < Balls.Length)
            {
                CurrentBall = Balls[CurrentBallIndex];
            }
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
                SplatBall();
            }
        }
        else
        {
            if (TimeElapsed >= TimePerScoopDeathNormal)
            {
                SplatBall();
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

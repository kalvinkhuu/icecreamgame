using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamCone : MonoBehaviour
{
    public GameObject[] Balls;

    private float TimeElapsed;

    private GameObject CurrentBall;
    private int CurrentBallIndex;

    public float TimePerScoopDeath = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        TimeElapsed = 0.0f;
        CurrentBallIndex = 0;
        CurrentBall = Balls[CurrentBallIndex];
    }

    // Update is called once per frame
    void Update()
    {
       TimeElapsed += Time.deltaTime;
       Debug.Log("Time Elapsed = " + TimeElapsed.ToString());
          
        if (TimeElapsed >= TimePerScoopDeath)
        {
            CurrentBall.SetActive(false);
            TimeElapsed = 0.0f;
            if (CurrentBallIndex < Balls.Length)
            {
                CurrentBallIndex++;
                CurrentBall = Balls[CurrentBallIndex];
            }
        }
               

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public float TimeToGoBackToMenu = 10.0f;
    private float TimeElapsed;
    private IceCreamPlayer[] Players;
    // Start is called before the first frame update
    void Start()
    {
        TimeElapsed = 0.0f;

        Players = GetComponentsInChildren<IceCreamPlayer>();

        Debug.Log("Winner: Player" + GameManager.PlayerWinOrder[0, 1]);
        GameObject FirstPlace = GameObject.Find("1stPlaceStartingPosition");
        GameObject SecondPlace = GameObject.Find("2ndPlaceStartingPosition");
        GameObject ThirdPlace = GameObject.Find("3rdPlaceStartingPosition");
        GameObject FourthPlace = GameObject.Find("4thPlaceStartingPosition");
        for (int i = 0; i < Players.Length; ++i)
        {
            if (Players[i].PlayerNumber == GameManager.PlayerWinOrder[0, 1])
            {
                Players[i].transform.position = FirstPlace.transform.position;
                Players[i].transform.rotation = FirstPlace.transform.rotation;
            }
            else if (Players[i].PlayerNumber == GameManager.PlayerWinOrder[1, 1]) 
            {
                Players[i].transform.position = SecondPlace.transform.position;
                Players[i].transform.rotation = SecondPlace.transform.rotation;
            }
            else if (Players[i].PlayerNumber == GameManager.PlayerWinOrder[2, 1])
            {
                Players[i].transform.position = ThirdPlace.transform.position;
                Players[i].transform.rotation = ThirdPlace.transform.rotation;
            }
            else 
            {
                Players[i].transform.position = FourthPlace.transform.position;
                Players[i].transform.rotation = FourthPlace.transform.rotation;
            }
    
        }



    }


    // Update is called once per frame
    void Update()
    {
        TimeElapsed += Time.deltaTime;
        if (TimeElapsed >= TimeToGoBackToMenu)
        {
            SceneManager.LoadScene(0);

        }


    }
}

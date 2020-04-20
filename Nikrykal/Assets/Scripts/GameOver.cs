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
        for (int i = Players.Length - 1; i >= MainMenu.ChosenNumPlayers; i--)
        {
            Players[i].gameObject.SetActive(false);
        }

        GameObject FirstPlace = GameObject.Find("1stPlaceStartingPosition");
        GameObject SecondPlace = GameObject.Find("2ndPlaceStartingPosition");
        GameObject ThirdPlace = GameObject.Find("3rdPlaceStartingPosition");
        GameObject FourthPlace = GameObject.Find("4thPlaceStartingPosition");

        if (GameManager.PlayerWinOrder == null)
        {
            Debug.Log("Testing Game Over");
            GameManager.PlayerWinOrder = new int[4, 2];
            for (int i = 0; i < 4; i++)
            {
                GameManager.PlayerWinOrder[i, 0] = 40 - (i * 10);
                GameManager.PlayerWinOrder[i, 1] = i + 1;
            }
        }

        for (int i = 0; i < Players.Length; ++i)
        {
            int playernumber = i + 1;
            if (playernumber == GameManager.PlayerWinOrder[0, 1])
            {
                Players[i].transform.position = FirstPlace.transform.position;
                Players[i].transform.rotation = FirstPlace.transform.rotation;
            }
            else if (playernumber == GameManager.PlayerWinOrder[1, 1])
            {
                Players[i].transform.position = SecondPlace.transform.position;
                Players[i].transform.rotation = SecondPlace.transform.rotation;
            }
            else if (playernumber == GameManager.PlayerWinOrder[2, 1])
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameChildPrefab;

    private GameObject [] GameChildren;
    public int MaxGameChildren = 10;
    public float GameTimeInMinutes = 3;
    public static float GameTimeInSeconds;
    private float TimeElapsed = 0.0f;
    private float TimeSinceLastSpawn = 0.0f;
    private float SpawnTimer = 1.0f;
    private bool GameOver = false;
    private float GameOverTimer;

    private IceCreamPlayer[] Players;
    private TextMeshProUGUI[] ScoreTexts;

    public static int[,] PlayerWinOrder;
    // Start is called before the first frame update
    void Start()
    {
        GameTimeInSeconds = GameTimeInMinutes * 60.0f;
        GameChildren = new GameObject[MaxGameChildren];
        for (int i = 0; i < MaxGameChildren; ++i)
        {
            GameChildren[i] = Instantiate(GameChildPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            GameChildren[i].SetActive(false);
        }

        Players = GetComponentsInChildren<IceCreamPlayer>();
        Canvas canvas = GetComponentInChildren<Canvas>();
        ScoreTexts = canvas.GetComponentsInChildren<TextMeshProUGUI>();
        Debug.Log("NumPlayersFound: " + Players.Length);
        Debug.Log("NumScoreTextsFound: " + ScoreTexts.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver)
        {
            GameOverTimer += Time.unscaledDeltaTime;
            if (GameOverTimer >= 5.0f)
            {
                Time.timeScale = 1.0f;
                Time.fixedDeltaTime = 0.02F;
                PlayerWinOrder = new int[4,2];

                System.Array.Sort(Players, delegate (IceCreamPlayer m, IceCreamPlayer n)
                { return m.GetScore().CompareTo(n.GetScore()); });
                System.Array.Reverse(Players);

                for (int i = 0; i < Players.Length; ++i)
                {
                    PlayerWinOrder[i,0] = Players[i].GetScore();
                    PlayerWinOrder[i, 1] = Players[i].PlayerNumber;
                }

                //for each player 
                //order by highest
                //set the player win order array
                SceneManager.LoadScene("GameOver");
            }
            return;
        }

        TimeElapsed += Time.deltaTime;
        if (TimeElapsed > GameTimeInMinutes * 60.0f)
        {
            GameOver = true;
            for (int i = 0; i < Players.Length; ++i)
            {
                Time.timeScale = 0.1f;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
            }
        }

        TimeSinceLastSpawn += Time.deltaTime;
        if (TimeSinceLastSpawn > SpawnTimer)
        {
            SpawnTimer = Random.Range(2.0f, 5.0f);
            TimeSinceLastSpawn = 0.0f;
            SpawnANewChild();
        }

        for (int i = 0; i < ScoreTexts.Length; ++i)
        {
            ScoreTexts[i].text = "Player " + (i + 1) + ":   " + Players[i].GetScore().ToString();
        }
    }
    
    void SpawnANewChild()
    {
        for (int i = 0; i < MaxGameChildren; ++i)
        {
            if (!GameChildren[i].activeSelf)
            {
                GameChildren[i].SetActive(true);
                int Multiplier = Random.Range(1, 4);
                Child child = GameChildren[i].GetComponent<Child>();
                if (Multiplier == 1)
                {
                    child.SetMultiplier(2);
                }
                else if (Multiplier == 2)
                {
                    child.SetMultiplier(3);
                }
                else if (Multiplier == 3)
                {
                    child.SetMultiplier(5);
                }

                float xRange = Random.Range(-15, 15);

                float maxZRange = 10;
                if (xRange > (-10 / 3.0f) && xRange < (10 / 3.0f))
                {
                    maxZRange = 6;
                }

                float zRange = Random.Range(-10,maxZRange);

                child.transform.position = new Vector3(xRange, 0.0f, zRange);

                break;
            }
        }
    }
    
}

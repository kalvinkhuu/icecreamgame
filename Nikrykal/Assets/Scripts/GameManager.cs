using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject GameChildPrefab;

    private GameObject [] GameChildren;
    public int MaxGameChildren = 10;
    public float GameTimeInMinutes = 3;
    private float TimeElapsed = 0.0f;
    private float TimeSinceLastSpawn = 0.0f;
    private float SpawnTimer = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        GameChildren = new GameObject[MaxGameChildren];
        for (int i = 0; i < MaxGameChildren; ++i)
        {
            GameChildren[i] = Instantiate(GameChildPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            GameChildren[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimeElapsed += Time.deltaTime;
        if (TimeElapsed > GameTimeInMinutes * 60.0f)
        {
            //GAME OVER
        }

        TimeSinceLastSpawn += Time.deltaTime;
        if (TimeSinceLastSpawn > SpawnTimer)
        {
            SpawnTimer = Random.Range(2.0f, 10.0f);
            TimeSinceLastSpawn = 0.0f;
            SpawnANewChild();
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

                float xRange = Random.Range(-19, 19);

                float maxZRange = 10;
                if (xRange > (-10 / 3.0f) && xRange < (10 / 3.0f))
                {
                    maxZRange = 6;
                }

                float zRange = Random.Range(-10,maxZRange);

                child.transform.position = new Vector3(xRange, 10.0f, zRange);

                break;
            }
        }
    }
    
}

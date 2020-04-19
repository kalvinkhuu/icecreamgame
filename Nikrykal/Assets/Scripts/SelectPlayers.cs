using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPlayers : MonoBehaviour
{
    //bool OnePlayer = false;
    //bool TwoPlayer = false;
    //bool ThreePlayer = false;
    //bool FourPlayer = false; 
    public void PlayGame()

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}

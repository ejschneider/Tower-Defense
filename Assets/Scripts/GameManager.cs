using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameOver = false;
    public GameObject gameOverUI;

    private void Start()
    {
        GameOver = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown("e")) EndGame();
        if (GameOver)
            return;
        if (PlayerStats.Lives <= 0 && !GameOver)
        {
            EndGame();
        }
    }

    void EndGame()
    {

        GameOver = true;
        gameOverUI.SetActive(true);
    }
}

using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text wavesText;

    void OnEnable()
    {
        wavesText.text = PlayerStats.Waves.ToString();
    }

    public void Retry()
    {
        //Generic code to auto load the currently selected scenes
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Debug.Log("Go to Menu");
    }
}

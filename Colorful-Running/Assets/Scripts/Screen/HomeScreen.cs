using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScreen : MonoBehaviour
{
    [SerializeField] private GameObject canvasHomeScreen;
    [SerializeField] private GameObject startGame;
    [SerializeField] private GameObject inGameScreen;
    public static bool initGame = false;

    void Start()
    {
        initGame = false;
        canvasHomeScreen.SetActive(true);
        startGame.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void StartGame()
    {
        initGame = true;
        startGame.SetActive(true);
        inGameScreen.SetActive(true);
        canvasHomeScreen.SetActive(false);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}

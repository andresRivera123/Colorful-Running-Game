using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    private bool pause = false;
    [SerializeField] private GameObject inGameScreen;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject canvasHomeScreen;

    public void IsPaused()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

    public void goHome()
    {
        pauseScreen.SetActive(false);
        canvasHomeScreen.SetActive(true);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("RunningForever");
    }
}

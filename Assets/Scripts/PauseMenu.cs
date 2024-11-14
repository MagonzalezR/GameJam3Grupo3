using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // public static PauseMenu Instance;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject controlls;
    [SerializeField] private GameObject mainmenu;
    [SerializeField] private GameObject gameOverPanel;
    public bool gameOver;

    // private void Awake()
    // {
    //     if (Instance == null)
    //     {
    //         Instance = this;
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    private void Start()
    {
        Time.timeScale = 1;
        gameOver = false;
        mainmenu.SetActive(true);
    }
    public void Pause ()
    {
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void Resume ()
    {
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void Home ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

        public void Controlls ()
    {
        mainmenu.SetActive(false);
        controlls.SetActive(true);
    }
    public void Restart ()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOverPanel()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        gameOver = true;
    }

}

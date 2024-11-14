using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject controlls;
    [SerializeField] private GameObject mainmenu;

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



}

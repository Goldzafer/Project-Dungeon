using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool pauseMenuActive;

    public PlayerMovement player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }
    }

    public void PauseMenu()
    {
        if (pauseMenuActive == false)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            pauseMenuActive = true;
        }
        else 
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            pauseMenuActive = false;
        }
    }

    public void ExitToMain() //(saves the players position using playerprefs) sets the time back to normal and loads the main menu
    {
        /*Vector3 playerPosition = player.transform.position;
        PlayerPrefs.SetFloat("playerPositionX", playerPosition.x);
        PlayerPrefs.SetFloat("playerPositionY", playerPosition.y);*/
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }

}

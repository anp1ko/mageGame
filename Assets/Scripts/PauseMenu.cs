
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject playerController;

    public GameObject weapon;

    public GameObject pauseMenuUI;

    public GameObject settingsMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        weapon.GetComponent<Weapon>().enabled = true;
        playerController.GetComponent<FirstPersonController>().enabled = true;
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        weapon.GetComponent<Weapon>().enabled = false;
        playerController.GetComponent<FirstPersonController>().enabled = false;
        pauseMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    private void Start()
    {
        // Ensure that the pause menu is initially inactive
        SetPauseMenuActive(false);
    }

    private void Update()
    {
        // Check for the Escape key
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Toggle the pause menu's active state
            TogglePauseMenu();
        }
    }

    private void TogglePauseMenu()
    {
        // Check if the pause menu is currently active
        bool isPaused = pauseMenu.activeSelf;

        // Toggle the active state
        SetPauseMenuActive(!isPaused);

        // Pause or resume the game based on the current state
        Time.timeScale = isPaused ? 1f : 0f;
    }

    private void SetPauseMenuActive(bool active)
    {
        // Set the active state of the pause menu GameObject
        pauseMenu.SetActive(active);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Transform mainMenu;
    public Transform settingsMenu;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.gameObject.SetActive(true);
        settingsMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPlayButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnSettingsButton()
    {
        settingsMenu.gameObject.SetActive(true);  
        mainMenu.gameObject.SetActive(false);
    }

    public void OnSettingsBackButton()
    {
        mainMenu.gameObject.SetActive(true);
        settingsMenu.gameObject.SetActive(false);
    }

    // Called when we click the "Quit" button.
    public void OnQuitButton()
    {
        Application.Quit();
    }
}

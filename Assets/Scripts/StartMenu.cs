using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Transform mainMenu;
    public Transform settingsMenu;
    bool isMainMenu;
    bool isSettingsMenu;
    //bool isLoadMenu;
    //bool isNewMenu;
    // Start is called before the first frame update
    void Start()
    {
        isMainMenu = true;
        isSettingsMenu = false;
        //isLoadMenu = false;
        //isNewMenu = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (isMainMenu)
            mainMenu.gameObject.SetActive(true);
        else if (isSettingsMenu)
            settingsMenu.gameObject.SetActive(true);
    }

    public void OnPlayButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnSettingsButton()
    {
        isSettingsMenu = true;
        isMainMenu = false;
        mainMenu.gameObject.SetActive(false);
    }

    public void OnSettingsBackButton()
    {
        isMainMenu = true;
        isSettingsMenu = false;
        settingsMenu.gameObject.SetActive(false);
    }

    // Called when we click the "Quit" button.
    public void OnQuitButton()
    {
        Application.Quit();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Transform mainMenu;
    public Transform settingsMenu;
    public Transform newGameMenu;

    public Transform inputMenu;
    public Transform loadGameMenu;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.gameObject.SetActive(true);
        settingsMenu.gameObject.SetActive(false);
        newGameMenu.gameObject.SetActive(false);
        loadGameMenu.gameObject.SetActive(false);
        inputMenu.gameObject.SetActive(false);
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
    public void OnNewGameButton()
    {
        newGameMenu.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
    }
    public void OnLoadGameButton()
    {
        loadGameMenu.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
    }
    public void OnSettingsBackButton()
    {
        mainMenu.gameObject.SetActive(true);
        settingsMenu.gameObject.SetActive(false);
    }
    public void OnNewGameBackButton()
    {
        mainMenu.gameObject.SetActive(true);
        newGameMenu.gameObject.SetActive(false);
    }

    public void onNewSaveGameButton(int fileParam)
    {

        PersistentParams.fileParameter = fileParam;
        newGameMenu.gameObject.SetActive(false);
        inputMenu.gameObject.SetActive(true);

    }
    public void OnLoadGameBackButton()
    {
        mainMenu.gameObject.SetActive(true);
        loadGameMenu.gameObject.SetActive(false);
    }
    // Called when we click the "Quit" button.
    public void OnQuitButton()
    {
        Application.Quit();
    }
}

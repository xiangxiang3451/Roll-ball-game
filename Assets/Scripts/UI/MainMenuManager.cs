using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Start game button click event
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("LevelSelect"); // Switch to the level selection scene
    }

    // Exit game button click event
    public void OnQuitButtonClicked()
    {
        Application.Quit(); // exit game
    }
}
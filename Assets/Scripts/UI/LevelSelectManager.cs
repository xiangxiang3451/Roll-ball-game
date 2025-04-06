using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1"); // 
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else

        Application.Quit();
#endif
    }
}
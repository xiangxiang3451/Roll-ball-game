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

    // 返回主菜单
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
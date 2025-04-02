using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollisionWithUI : MonoBehaviour
{
    public GameObject failPanel;

    private void Start()
    {
        failPanel.SetActive(false); // hide dulu
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            failPanel.SetActive(true);
            Time.timeScale = 0f; // pause game
        }
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // Ganti nama scene kalau perlu
    }
}

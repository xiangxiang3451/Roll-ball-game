using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public float levelTime = 20f; // durasi waktu per level
    private float currentTime;

    public TextMeshProUGUI timerText;
    public GameObject failPanel; // sama seperti panel saat kena enemy

    private void Start()
    {
        Time.timeScale = 1f; // PENTING! Reset ke normal saat scene dimulai
        currentTime = levelTime;
        failPanel.SetActive(false);
    }


    void Update()
    {
        currentTime -= Time.deltaTime;
        currentTime = Mathf.Clamp(currentTime, 0, levelTime);
        timerText.text = "Time: " + Mathf.Ceil(currentTime).ToString();

        if (currentTime <= 5f)
        {
            timerText.color = Color.red;
        }
        else
        {
            timerText.color= Color.white;
        }

        if (currentTime <= 0)
        {
            TimeUp();
        }
    }
    void TimeUp()
    {
        Time.timeScale = 0f;
        failPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

}
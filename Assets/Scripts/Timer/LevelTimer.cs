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

    void Start() 
    {
        currentTime = levelTime;

        if (failPanel != null)
            failPanel.SetActive(false); // pastikan panel hidden di awal
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
        if (failPanel != null)
        {
            Time.timeScale = 0f;
            failPanel.SetActive(true);
        }
        else
        {
            Debug.LogWarning("FailPanel belum disambungkan di Inspector!");
        }
    }


    //public void RestartLevel()
    //{
      //  Time.timeScale = 1f;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}
    public void RestartLevel()
    {
        Debug.Log("Restart button pressed!"); // Tambah ini
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

}
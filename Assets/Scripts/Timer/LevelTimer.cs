using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class LevelTimer : MonoBehaviour
{
    public float levelTime = 20f;
    private float currentTime;
    private bool isTimerRunning = true; // 添加计时器运行状态

    public TextMeshProUGUI timerText;
    public GameObject failPanel;

    private void Start()
    {
        Time.timeScale = 1f;
        currentTime = levelTime;
        failPanel.SetActive(false);
        isTimerRunning = true; // 初始时计时器运行
    }

    void Update()
    {
        if (!isTimerRunning) return; // 如果计时器停止，不再更新

        currentTime -= Time.deltaTime;
        currentTime = Mathf.Clamp(currentTime, 0, levelTime);
        timerText.text = "Time: " + Mathf.Ceil(currentTime).ToString();

        if (currentTime <= 5f)
        {
            timerText.color = Color.red;
        }
        else
        {
            timerText.color = Color.white;
        }

        if (currentTime <= 0)
        {
            TimeUp();
        }
    }

    // 添加停止计时器的方法
    public void StopTimer()
    {
        isTimerRunning = false;
    }

    void TimeUp()
    {
        if (PlayerController.GameCompleted) return; // 如果游戏已完成，不执行失败逻辑

        Time.timeScale = 0f;
        failPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        StartCoroutine(RestartAfterUnpause());
    }

    IEnumerator RestartAfterUnpause()
    {
        Time.timeScale = 1f;
        yield return new WaitForSecondsRealtime(0.1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        StartCoroutine(BackToMenuAfterUnpause());
    }

    IEnumerator BackToMenuAfterUnpause()
    {
        Time.timeScale = 1f;
        yield return new WaitForSecondsRealtime(0.1f);
        SceneManager.LoadScene("MainMenu");
    }
}
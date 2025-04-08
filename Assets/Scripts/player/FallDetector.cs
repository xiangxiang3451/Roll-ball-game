using UnityEngine;

public class FallDetector : MonoBehaviour
{
    public GameObject failPanel;
    public float fallThresholdY = -5f;

    private bool hasFallen = false;

    void Update()
    {
        if (!hasFallen && transform.position.y < fallThresholdY)
        {
            hasFallen = true;
            Time.timeScale = 0f;

            if (failPanel != null)
            {
                failPanel.SetActive(true);
            }
            else
            {
                Debug.LogWarning("FailPanel belum di-assign di FallDetector!");
            }
        }
    }
}



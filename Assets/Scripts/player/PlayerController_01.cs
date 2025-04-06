using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private int count;
    private int countCoub;
    public Text countText, winText;

    // 添加一个标志表示游戏是否结束
    public static bool GameCompleted { get; private set; }

    // Audio
    public AudioClip coinCollectSound;
    public AudioSource backgroundMusic;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        winText.text = "";
        countCoub = GameObject.FindGameObjectsWithTag("coins").Length;
        setCount();
        GameCompleted = false; // 重置游戏完成状态

        if (backgroundMusic == null)
        {
            backgroundMusic = GameObject.Find("AudioManager").GetComponent<AudioSource>();
        }
        backgroundMusic.Play();
    }

    private void FixedUpdate()
    {
        // 如果游戏完成，不再添加力
        if (GameCompleted) return;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coins"))
        {
            AudioSource.PlayClipAtPoint(coinCollectSound, transform.position, 1f);
            Destroy(other.gameObject);
            count++;
            setCount();
        }
    }

    private void setCount()
    {
        countText.text = "Количество: " + count.ToString();
        if (count >= countCoub)
        {
            winText.text = "Победа!!!";
            backgroundMusic.Stop();
            GameCompleted = true; // 设置游戏完成标志

            // 冻结刚体
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;

            // 通知所有计时器停止
            LevelTimer[] timers = FindObjectsOfType<LevelTimer>();
            foreach (var timer in timers)
            {
                timer.StopTimer();
            }
        }
    }
}
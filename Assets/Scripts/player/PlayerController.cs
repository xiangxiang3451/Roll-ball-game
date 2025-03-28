using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    //public GameManager gameManager; // Reference ke GameManager


    int score = 0;
    //public int winScore;
    //public GameObject winText;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);
            score++;

            //if (score >= winScore)
            //{
                // game win
              //  winText.SetActive(true);
               // gameManager.WinGame(); // Tampilkan WinPanel
            //}
        }

    }

    // Ketika player menang
    //void PlayerWins()
    //{
    //  gameManager.WinGame(); // Tampilkan WinPanel
    //}
}


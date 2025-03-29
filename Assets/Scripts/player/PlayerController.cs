using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    /// количество собранных кубов
    private int count;
    /// Изначальное количество кубов
    private int countCoub;
    /// текстовые поля
    public Text countText, winText;



    // Audio
    public AudioClip coinCollectSound; // coinCollectSound
    public AudioSource backgroundMusic;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0; /// по умолчанию собрано 0 кубов
        winText.text = ""; /// текст победы по умолчанию скрыт
                           /// получаем количество элементов с тегом cubes
        countCoub = GameObject.FindGameObjectsWithTag("coins").Length;
        setCount();


        if (backgroundMusic == null)
        {
            backgroundMusic = GameObject.Find("AudioManager").GetComponent<AudioSource>();
        }
        backgroundMusic.Play(); // bgsound
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
        if (other.CompareTag("coins"))
        {
            // play coinCollectsound
            AudioSource.PlayClipAtPoint(coinCollectSound, transform.position, 1f);

            Destroy(other.gameObject);
            count++;
            setCount();
        }
    }
    /// <summary>
    /// Функция изменения текстов
    /// </summary>
    private void setCount()
    {
        countText.text = "Количество: " + count.ToString();
        if (count >= countCoub)
        {
            winText.text = "Победа!!!";
            backgroundMusic.Stop();
        }
    }
}

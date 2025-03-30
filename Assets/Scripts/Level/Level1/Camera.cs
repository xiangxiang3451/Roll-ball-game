using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    private Vector3 offset;
    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}

using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;

    private void FixedUpdate()
    {
        transform.LookAt(target);
    }
}

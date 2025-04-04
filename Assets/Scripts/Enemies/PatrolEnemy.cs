using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 3f;

    private Vector3 target;

    void Start()
    {
        target = pointB.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            // Ganti target ke titik sebaliknya
            target = (target == pointA.position) ? pointB.position : pointA.position;
        }
    }
}

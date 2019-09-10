using UnityEngine;

public class Agent : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    private Vector3 desired = Vector3.zero;
    private Vector3 steer = Vector3.zero;
    private Vector3 limit = Vector3.zero;

    private float maxSpeed = 10;
    private float maxSteer = 20;

    private Transform target;
    private Transform detect;

    void Awake()
    {
        detect = GameObject.Find("Detector").transform;
        target = GameObject.Find("Target").transform;
        limit = new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight);
    }

    void Update()
    {
        desired = -(target.position - transform.position).normalized * maxSpeed;
        steer = Vector3.ClampMagnitude(desired - velocity, maxSteer);

        velocity += steer * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        if((detect.position - transform.position).sqrMagnitude < 4f)
        {
            Debug.Log("WIN!!!");
            Destroy(gameObject);
        }

        Vector3 objPos = Camera.main.WorldToScreenPoint(transform.position);

        if(objPos.x > limit.x || objPos.y > limit.y || objPos.x < 0 || objPos.y < 0)
        {
            Debug.Log("LOSE!!");
            Destroy(gameObject);
        }
    }
}

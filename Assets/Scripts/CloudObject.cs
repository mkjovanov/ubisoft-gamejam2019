using UnityEngine;

public class CloudObject : MonoBehaviour
{
    public float DurationSecs = 10;

    float CreationTime;

    void Start()
    {
        CreationTime = Time.time;
    }

    void Update()
    {
        if (Time.time - CreationTime > DurationSecs)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FlameableObject>())
        {
            other.GetComponent<FlameableObject>().IsOnFire = false;
        }
    }
}

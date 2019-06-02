using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindForce : MonoBehaviour
{
    public float DurationSecs = 5;

    float CreationTime;
    // Start is called before the first frame update
    void Start()
    {
        CreationTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - CreationTime > DurationSecs)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>() != null)
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(0f, 10f) - 5, Random.Range(10f, 14f), Random.Range(0f, 10f) - 5), ForceMode.Impulse);
            other.gameObject.GetComponent<Rigidbody>().AddTorque(transform.up * Random.Range(10f, 18f));
        }
    }
}
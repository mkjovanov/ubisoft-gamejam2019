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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>() != null)
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * Random.Range(1,2), ForceMode.Impulse);
        }
    }
}
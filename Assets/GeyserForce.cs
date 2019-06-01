using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeyserForce : MonoBehaviour
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
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, .8f - (other.transform.position.y - other.transform.localScale.y/2f - transform.position.y + transform.localScale.y/2f)/3f, 0), ForceMode.Impulse);
            other.gameObject.GetComponent<Rigidbody>().AddTorque(transform.up * Random.Range(0f,2f));
        }
    }
}
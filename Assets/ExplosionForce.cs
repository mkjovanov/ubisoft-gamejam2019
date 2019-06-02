using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionForce : MonoBehaviour
{
    public float DurationSecs = 1;
    public GameObject MeatCube;

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
        if (other.gameObject.GetComponent<EnemyMovement>() != null)
        {
            var pos = other.gameObject.transform.position;
            other.enabled = false;
            Destroy(other);

            for (int i = 0; i < 5; i++)
            {
                GameObject m = Instantiate(MeatCube, pos + Vector3.up * Random.Range(0f,2.5f), Quaternion.identity);
                m.GetComponent<Rigidbody>().AddForce(
                new Vector3(Random.Range(-5f,5f), Random.Range(1f, 10f), Random.Range(-5f,5f)), ForceMode.Impulse);
                m.GetComponent<Rigidbody>().AddTorque(transform.up * Random.Range(-15, 15f));
            }
        }
    }
}
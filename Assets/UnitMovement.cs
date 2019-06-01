using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    int jumpCounter;

    // Start is called before the first frame update
    void Start()
    {
        jumpCounter = Random.Range(100, 150);
    }

    void FixedUpdate()
    {
        if (jumpCounter-- < 1)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 3, ForceMode.Impulse);
            jumpCounter = Random.Range(25, 75);
        }
    }
}

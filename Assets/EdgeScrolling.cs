using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeScrolling : MonoBehaviour
{
    private int mSpeed = 24;
    private int mDelta = 40;

    public Transform Ground;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = transform.position;
        if (Input.mousePosition.x >= Screen.width - mDelta || Input.GetKey(KeyCode.D))
        {
            targetPos += transform.right * Time.deltaTime * mSpeed;
        }
        if (Input.mousePosition.x <= 0 + mDelta || Input.GetKey(KeyCode.A))
        {
            targetPos -= transform.right * Time.deltaTime * mSpeed;
        }
        if (Input.mousePosition.y >= Screen.height - mDelta || Input.GetKey(KeyCode.W))
        {
            targetPos += transform.forward * Time.deltaTime * mSpeed;
        }
        if (Input.mousePosition.y <= 0 + mDelta || Input.GetKey(KeyCode.S))
        {
            targetPos -= transform.forward * Time.deltaTime * mSpeed;
        }
        var finalX = targetPos.x;
        var finalZ = targetPos.z;
        if (finalX < Ground.position.x - Ground.localScale.x / 2 - 5)
        {
            finalX = Ground.position.x - Ground.localScale.x / 2 - 5;
        }
        if (finalX > Ground.position.x + Ground.localScale.x / 2 + 5)
        {
            finalX = Ground.position.x + Ground.localScale.x / 2 + 5;
        }
        if (finalZ < Ground.position.z - Ground.localScale.z / 2 - 5)
        {
            finalZ = Ground.position.z - Ground.localScale.z / 2 - 5;
        }
        if (finalZ > Ground.position.z + Ground.localScale.z / 2 + 5)
        {
            finalZ = Ground.position.z + Ground.localScale.z / 2 + 5;
        }
        
        transform.position = new Vector3(finalX, transform.position.y, finalZ);
    }
}

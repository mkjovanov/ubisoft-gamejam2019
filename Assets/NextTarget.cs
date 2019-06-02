using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextTarget : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PersonMovement>() != null)
        {
            other.gameObject.GetComponent<PersonMovement>().nextTarget();
        }
    }
}

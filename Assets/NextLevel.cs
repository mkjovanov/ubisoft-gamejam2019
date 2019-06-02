using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    private int delayCount = 200;
    private bool triggered = false;
    public Text label;

    private void Update()
    {
        if (triggered)
        {
            delayCount--;
            if (delayCount < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PersonMovement>() != null)
        {
            triggered = true;
            label.enabled = true;
        }
    }
}

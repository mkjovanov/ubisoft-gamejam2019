using UnityEngine;

public class CloudObject : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        other.GetComponent<FlameableObject>().IsOnFire = false;
    }
}

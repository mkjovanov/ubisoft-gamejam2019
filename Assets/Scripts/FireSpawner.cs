using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.Instance.IsFireActivated)
        {
            SpawnFire();
        }
    }

    private void SpawnFire()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            var hitObj = hit.transform.gameObject.GetComponent<FlameableObject>();
            if (hitObj != null)
            {
                hit.transform.gameObject.GetComponent<FlameableObject>().IsOnFire = true;
            }
        }
    }
}

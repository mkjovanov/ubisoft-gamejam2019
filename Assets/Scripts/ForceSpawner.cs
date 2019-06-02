using UnityEngine;

public class ForceSpawner : MonoBehaviour
{
    public GameObject ForceObject;
    public GameObject Ground;
    public LayerMask LayerHit;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.Instance.IsForceActivated)
        {
            SpawnForce();
        }
    }

    private void SpawnForce()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction, Color.green);
        if (Physics.Raycast(ray, out RaycastHit hit, 200, LayerHit))
        {
            var hitPos = hit.point;
            Instantiate(ForceObject, hitPos + new Vector3(0, .5f, 0), Quaternion.identity);
        }
    }
    
}

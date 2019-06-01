using UnityEngine;

public class GeyserSpawner : MonoBehaviour
{
    public GameObject GeyserObject;
    public GameObject Ground;
    public LayerMask LayerHit;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SpawnGeyser();
        }
    }

    private void SpawnGeyser()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction, Color.green);
        if (Physics.Raycast(ray, out RaycastHit hit, 200, LayerHit))
        {
            var hitPos = hit.point;
            Instantiate(GeyserObject, hitPos + new Vector3(0, .5f, 0), Quaternion.identity);
        }
    }
    
}

using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject RainObject;
    public GameObject Ground;
    public LayerMask LayerHit;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SpawnCloud();
        }
    }

    private void SpawnCloud()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction, Color.green);
        if (Physics.Raycast(ray, out RaycastHit hit, 200, LayerHit))
        {
            var hitPos = hit.point;
            var _spawnedObject = Instantiate(RainObject, hitPos + new Vector3(0, 4.5f, 0), Quaternion.identity);
            _spawnedObject.gameObject.AddComponent<CloudObject>();
        }
    }
}

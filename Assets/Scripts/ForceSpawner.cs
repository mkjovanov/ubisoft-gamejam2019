using UnityEngine;

public class ForceSpawner : MonoBehaviour
{
    public GameObject ForceObject;
    public GameObject Ground;

    private GameObject _spawnedObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnForce();
        }
        if (Input.GetMouseButton(0))
        {
            MoveForce();
        }
        if (Input.GetMouseButtonUp(0))
        {
            DestroyForce();
        }
    }

    private void SpawnForce()
    {
        var mousePos = Input.mousePosition;
        if (_spawnedObject == null)
        {
            var objectPos = Camera.allCameras[0].ScreenToWorldPoint(mousePos);
            objectPos.z = Ground.transform.position.z;
            _spawnedObject = Instantiate(ForceObject, objectPos, Quaternion.identity);
        }
    }

    private void MoveForce()
    {
        var pos = Input.mousePosition;
        pos.z = -Camera.main.transform.position.z;
        pos = Camera.main.ScreenToWorldPoint(pos);
        _spawnedObject.transform.position = pos;
    }

    private void DestroyForce()
    {
        Destroy(_spawnedObject);
    }
}

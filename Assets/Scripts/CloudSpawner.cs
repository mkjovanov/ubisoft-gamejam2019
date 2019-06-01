using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject RainObject;
    public GameObject Ground;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnCloud();
        }
    }

    private void SpawnCloud()
    {
        var mousePos = Input.mousePosition;
        var pos = Input.mousePosition;
        pos.z = -Camera.main.transform.position.z;
        pos = Camera.main.ScreenToWorldPoint(pos);
        var _spawnedObject = Instantiate(RainObject, pos, Quaternion.identity);
        _spawnedObject.transform.position = pos;
        _spawnedObject.gameObject.AddComponent<CloudObject>();
    }
}
